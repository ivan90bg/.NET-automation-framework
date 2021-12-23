﻿using Everstox.API.IntegrationTests.Static_Data;
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

namespace Everstox.API.IntegrationTests.SFTP_Integration_Tests
{
    [TestClass]
    public class UploadOrderXML_CheckOnCore
    {
        [DataTestMethod]
        [DataRow("TestOrder1", "TestFulfillment_1")]
        public async Task UploadOrderXML_CheckOnCore_ShouldReturnCorrectStatusCode(string xentralOrderXML, string newFulfillmentName)
        {

            SFTPHandlers.UploadSFTPXentral(xentralOrderXML);
            var orderNumber = XMLOrderValueExtractor(xentralOrderXML, "auftrag");

            var triggerResponse = await XentralSyncTrigger();
            ValidateTriggeredResponseOnXentral(triggerResponse);

            await Task.Delay(6000);

            var orderResponse = await GerOrderByNameFromXML(orderNumber);
            ValidateXentralOrderIsOnCore(orderNumber, orderResponse);

            await Task.Delay(9000);

            SFTPHandlers.DownloadSFTPStorelogix(orderNumber, newFulfillmentName);

            var order_City = XMLOrderValueExtractor(xentralOrderXML, "rechnung_ort");
            var fulfillment_City = XMLFulfillmentsXpathValueExtractor(newFulfillmentName, "Invoicing/Address/City");

            Assert.AreEqual(order_City, fulfillment_City, "Mapped values are not the same!");
        }


        private void ValidateXentralOrderIsOnCore(string orderNumber, IRestResponse<OrderList_Response> orderResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, orderResponse.StatusCode, orderResponse.Content.ToString());
            Assert.AreEqual(orderNumber, orderResponse.Data.items[0].order_number, orderResponse.Content.ToString());
        }

        private void ValidateTriggeredResponseOnXentral(IRestResponse triggerResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, triggerResponse.StatusCode, triggerResponse.Content.ToString());
        }

        private async Task<IRestResponse<OrderList_Response>> GerOrderByNameFromXML(string orderNumber)
        {
            var orderService = new OrderService();
            return await orderService.GetOrderByNumber(Shops.QA1Shop_Id, orderNumber);
           
        }

        public string XMLOrderValueExtractor(string fileName, string nodeValue)
        {
            var sourceFile = @"..\..\..\Xentral_Orders\" + fileName + ".xml".Replace('\\', Path.PathSeparator);
            var data = XElement.Load(sourceFile);
            return data.Descendants(nodeValue).FirstOrDefault().Value;
        }

        public string XMLOrderXpathValueExtractor(string fileName, string nodeValue)
        {
            var sourceFile = @"..\..\..\Xentral_Orders\" + fileName + ".xml";
            var data = XElement.Load(sourceFile);
            return data.XPathSelectElement($"//*/{nodeValue}").Value;
        }

        public string XMLFulfillmentValueExtractor(string fileName, string nodeValue)
        {
            var sourceFile = @"..\..\..\Storelogix_Fulfillments\" + fileName + ".xml";
            var data = XElement.Load(sourceFile);
            return data.Descendants(nodeValue).FirstOrDefault().Value;
        }

        public string XMLFulfillmentsXpathValueExtractor(string fileName, string nodeValue)
        {
            var sourceFile = @"..\..\..\Storelogix_Fulfillments\" + fileName + ".xml";
            var data = XElement.Load(sourceFile);
            return data.XPathSelectElement($"//*/{nodeValue}").Value;
        }

        public async Task<IRestResponse> XentralSyncTrigger()
        {
            var client = new RestClientHandler("https://sc-xentral.qa1.everstox.com/orders/sync");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization("api-token", "f36ab4c7-c64d-4f9e-aae3-ad834175b313")
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync(request);
        }
    }
}
