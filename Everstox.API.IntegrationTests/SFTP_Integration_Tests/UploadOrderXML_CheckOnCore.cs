using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Orders;
using Everstox.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
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

            var triggerResponse = await XentralSyncTrigger();
            Assert.AreEqual(HttpStatusCode.OK, triggerResponse.StatusCode, triggerResponse.Content.ToString());

            await Task.Delay(6000);

            var orderNumber = XMLOrderValueExtractor(xentralOrderXML, "auftrag");

            var orderService = new OrderService();
            var orderResponse = await orderService.GetOrderByNumber(Shops.QA1Shop_Id, orderNumber);

            Assert.AreEqual(HttpStatusCode.OK, orderResponse.StatusCode, orderResponse.Content.ToString());
            Assert.AreEqual(orderNumber, orderResponse.Data.items[0].order_number, orderResponse.Content.ToString());

            await Task.Delay(9000);
            SFTPHandlers.DownloadSFTPStorelogix(orderNumber, newFulfillmentName);

            var orderCity = XMLOrderValueExtractor(xentralOrderXML, "rechnung_ort");
            var fulfillmentCity = XMLFulfillmentsXpathValueExtractor(newFulfillmentName, "Invoicing/Address/City");

            Assert.AreEqual(orderCity, fulfillmentCity, "Mapped values are not the same!");
        }

        public string XMLOrderValueExtractor(string fileName, string nodeValue)
        {
            var sourceFile = @"..\..\..\Xentral_Orders\" + fileName + ".xml";
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

        public async Task<IRestResponse<object>> XentralSyncTrigger()
        {
            var client = new RestClientHandler("https://sc-xentral.qa1.everstox.com/orders/sync");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization("api-token", "f36ab4c7-c64d-4f9e-aae3-ad834175b313")
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<object>(request);
        }
    }
}
