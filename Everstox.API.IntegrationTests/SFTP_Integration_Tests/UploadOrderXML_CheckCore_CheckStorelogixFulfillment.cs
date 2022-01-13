using System;
using System.Diagnostics;
using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Orders;
using Everstox.API.Shop.Orders.Models.Response_Models;
using Everstox.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Polly;
using System.Xml;
using System.Text;

namespace Everstox.API.IntegrationTests.SFTP_Integration_Tests
{
    [TestClass]
    public class UploadOrderXML_CheckCore_CheckStorelogixFulfillment
    {
        [DataTestMethod]
        [DataRow("TestOrder1", "TestFulfillment_1")]
        public async Task UploadOrderXML_CheckCore_CheckStorelogixFulfillment_ShouldReturnCorrectData(string xentralOrderXML, string newFulfillmentName)
        {
           
            XmlOrderNodeValueChange(xentralOrderXML, "auftrag", $"SFTPAuto{new Random().Next(1000)}");

            SFTPHandlers.UploadSFTPXentral(xentralOrderXML);

            var orderNumber = XmlOrderSingleValueExtractor(xentralOrderXML, "auftrag");

            var triggerResponse = await XentralSyncTrigger();
            ValidateTriggeredResponseOnXentral(triggerResponse);

            await GetOrRetryOrderResponse(orderNumber);

            SFTPHandlers.DownloadSFTPStorelogix(orderNumber, newFulfillmentName);

            var order_City = XmlOrderSingleValueExtractor(xentralOrderXML, "rechnung_ort");
            var fulfillment_City = XmlFulfillmentsXpathValueExtractor(newFulfillmentName, "Invoicing/Address/City");

            Assert.AreEqual(order_City, fulfillment_City, "Mapped values are not the same!");

        }

        private async Task<PolicyResult<IRestResponse<OrderList_Response>>> GetOrRetryOrderResponse(string orderNumber)
        {
            PolicyResult<IRestResponse<OrderList_Response>>? orderResponse = await Policy.Handle<Exception>()
                .OrResult<IRestResponse<OrderList_Response>>(r => !r.IsSuccessful || r.Data.count < 1)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (response, timeSpan, retryAttempt, context) =>
                    {
                        Debug.WriteLine(retryAttempt);
                        Debug.WriteLine(timeSpan);
                        Debug.WriteLine(response.Result.Content);
                    }).ExecuteAndCaptureAsync(async () => await GetOrderByNameFromXML(orderNumber));

            return orderResponse;
        }

        private void ValidateTriggeredResponseOnXentral(IRestResponse triggerResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, triggerResponse.StatusCode, triggerResponse.Content.ToString());
        }

        private async Task<IRestResponse<OrderList_Response>> GetOrderByNameFromXML(string orderNumber)
        {
            var orderService = new OrderService();
            return await orderService.GetOrderByNumber(Shops.QA1Shop_Id, orderNumber);
        }

        private string XmlOrderSingleValueExtractor(string fileName, string nodeValue)
        {
            var path = "..\\..\\..\\Xentral_Orders\\" + fileName + ".xml";
            var sourceFile = path.Replace('\\', Path.PathSeparator);
            var data = XElement.Load(sourceFile);
            return data.Descendants(nodeValue).Single().Value;
        }

        private void XmlOrderNodeValueChange(string fileName, string nodeValue, string newValue)
        {
            var path = "..\\..\\..\\Xentral_Orders\\" + fileName + ".xml";
            var sourceFile = path.Replace('\\', Path.PathSeparator);
            var data = XElement.Load(sourceFile);
            var valueForUpdate = data.Descendants().Where(n => n.Name == nodeValue).ToList().Single().Value = newValue;
            using (var writer = new StreamWriter(sourceFile, false, new UTF8Encoding(false)))
            {
                data.Save(writer);
            }               
            
        }

        private string XmlFulfillmentsXpathValueExtractor(string fileName, string nodeValue)
        {
            var path = @"..\\..\\..\\Storelogix_Fulfillments\\" + fileName + ".xml";
            var sourceFile = path.Replace('\\', Path.PathSeparator);
            var data = XElement.Load(sourceFile);
            return data.XPathSelectElement($"//*/{nodeValue}").Value;
        }

        private async Task<IRestResponse> XentralSyncTrigger()
        {
            var client = new RestClientHandler("https://sc-xentral.qa1.everstox.com/orders/sync");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization("api-token", Shops.Xentral_Id)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync(request);
        }

        private string XmlOrderXpathValueExtractor(string fileName, string nodeValue)
        {
            var path = @"..\\..\\..\\Xentral_Orders\\" + fileName + ".xml";
            var sourceFile = path.Replace('\\', Path.PathSeparator);
            var data = XElement.Load(sourceFile);
            return data.XPathSelectElement($"//*/{nodeValue}").Value;
        }

        private string XmlFulfillmentValueExtractor(string fileName, string nodeValue)
        {
            var path = @"..\\..\\..\\Storelogix_Fulfillments\\" + fileName + ".xml";
            var sourceFile = path.Replace('\\', Path.PathSeparator);
            var data = XElement.Load(sourceFile);
            return data.Descendants(nodeValue).Single().Value;
        }
    }
}