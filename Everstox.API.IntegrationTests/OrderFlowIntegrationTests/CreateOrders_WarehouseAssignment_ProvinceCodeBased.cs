using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Orders;
using Everstox.API.Shop.Orders.Models.Request_Models;
using Everstox.API.Shop.Orders.Models.Response_Models;
using Everstox.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using static Everstox.Infrastructure.Infrastructure_Data.EverstoxAPIData;

namespace Everstox.API.IntegrationTests.OrderFlowIntegrationTests
{
    [TestClass]
    public class CreateOrders_WarehouseAssignment_ProvinceCodeBased
    {
        
        [DeploymentItem(@".\Test_Data\")]
        [DataTestMethod]
        [DataRow("FSoda", "German_WH", "US", "AL")]
        [DataRow("FSoda", "German_WH", "US", null)]
        [DataRow("FSoda", "German_WH", "US", "HI")]
        [DataRow("RSoda", "USA_WH2", "US", "AL")]
        [DataRow("RSoda", "USA_WH2", "US", "FL")]
        [DataRow("RSoda", "USA_WH1", "US", null)]
        [DataRow("RSoda", "USA_WH1", "US", "CO")]
        [DataRow("ASoda", "USA_WH1", "US", "UT")]
        [DataRow("ASoda", "USA_WH1", "US", "TX")]
        [DataRow("ASoda", "USA_WH2", "US", "CO")]
        [DataRow("ASoda", "USA_WH2", "US", "NJ")]
        [DataRow("ASoda", "German_WH", "US", null)]
        [DataRow("PSoda", "German_WH", "US", "AL")]
        [DataRow("PSoda", "USA_WH2", "US", "CO")]
        [DataRow("PSoda", "USA_WH2", "US", null)]
        [DataRow("Dsoda", "German_WH", "IT", null)]
        [DataRow("Dsoda", "German_WH", "DE", null)]
        [DataRow("Dsoda", "FBack_WH", "SE", null)]
        [DataRow("ASoda", "German_WH", "SE", null)]
        [DataRow("guarana", "USA_WH2", "SE", null)]
        
        public async Task CreateOrder_CheckWarehouseBasedOnProvinceCodeAssignmentStrategy(string productSku, string expectedWarehouse, string country_code, string provinceCode)
        {
            var orderRequest = GenerateOrderRequestFromJson("OrderForWHAssignmentStrategy.json", productSku, country_code, provinceCode);
            var orderResponse = await CreateOrder(orderRequest);

            ValidateOrder(orderResponse, expectedWarehouse);
        }

        private Order_Request GenerateOrderRequestFromJson(string fileName, string sku, string country_code, string? province_code = null)
        {
            var orderRequest = RequestDeserializer.Deserialize<Order_Request>(fileName);
            orderRequest.order_number = $"WHASOrder{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8)}";
            orderRequest.order_date = DateTime.Now;
            orderRequest.shipping_address.province_code = province_code;
            orderRequest.order_items[0].product.sku = sku;
            orderRequest.shipping_address.country_code = country_code;
            return orderRequest;
        }
       
        private async Task<IRestResponse<Order_Response>> CreateOrder(Order_Request orderRequest)
        {
            var orderService = new OrderService();
            return await orderService.CreateOrder(Shops.IV_Shop_Id, orderRequest);

        }

        private void ValidateOrder(IRestResponse<Order_Response> orderResponse, string warehouseName)
        {
            Assert.AreEqual(HttpStatusCode.Created, orderResponse.StatusCode, orderResponse.Content.ToString());          
            Assert.AreEqual(warehouseName, orderResponse.Data.fulfillments[0].warehouse.name);
            
        }
    }
}