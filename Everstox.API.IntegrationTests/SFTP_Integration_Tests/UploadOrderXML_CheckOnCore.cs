using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Orders;
using Everstox.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Everstox.API.IntegrationTests.SFTP_Integration_Tests
{
    [TestClass]
    public class UploadOrderXML_CheckOnCore
    {
        [DataTestMethod]
        [DataRow("TestOrder1.xml", "automationSFTP1", "automationSFTP1.xml", "shipment1.xml")]
        [DataRow("TestOrder2.xml", "automationSFTP2", "automationSFTP2.xml", "shipment2.xml")]
        [DataRow("TestOrder3.xml", "automationSFTP3", "automationSFTP3.xml", "shipment3.xml")]
        public async Task UploadOrderXML_CheckOnCore_ShouldReturnCorrectStatusCode(string xentralOrderXML, string expectedName, string shipmentName, string shipmentNewName) 
        {
            SFTPHandlers.UploadSFTPXentral(xentralOrderXML);

            var triggerResponse = await XentralSyncTrigger();
            Assert.AreEqual(HttpStatusCode.OK, triggerResponse.StatusCode, triggerResponse.Content.ToString());

            Thread.Sleep(6000);

            var orderService = new OrderService();
            var orderResponse = await orderService.GetLastCreatedOrder(Shops.QA1Shop_Id);

            Assert.AreEqual(HttpStatusCode.OK, orderResponse.StatusCode, orderResponse.Content.ToString());
            Assert.AreEqual(expectedName, orderResponse.Data.items[0].order_number, orderResponse.Content.ToString());

            Thread.Sleep(9000);
            SFTPHandlers.DownloadSFTPStorelogix(shipmentName, shipmentNewName);

        }

        public bool FileExists(string fileName)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var file = $"{workingDirectory}/{fileName}";
            return File.Exists(file);
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
