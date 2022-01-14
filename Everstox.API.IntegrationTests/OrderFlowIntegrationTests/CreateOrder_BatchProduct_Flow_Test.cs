using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Orders;
using Everstox.API.Shop.Orders.Models.Request_Models;
using Everstox.API.Shop.Orders.Models.Response_Models;
using Everstox.API.Warehouses.Fulfillments;
using Everstox.API.Warehouses.Fulfillments.Models.Request_Model;
using Everstox.API.Warehouses.Fulfillments.Models.Response_Model;
using Everstox.API.Warehouses.Shipments;
using Everstox.API.Warehouses.Shipments.Models.Request_Models;
using Everstox.API.Warehouses.Shipments.Models.Response_Models;
using Everstox.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static Everstox.Infrastructure.Infrastructure_Data.EverstoxAPIData;

namespace Everstox.API.IntegrationTests.OrderFlowIntegrationTests
{
    [TestClass]
    public class CreateOrder_BatchProduct_Flow_Test
    {
        [DeploymentItem(@".\Test_Data\")]
        [TestMethod]
        public async Task CreateOrder_WithBatchProduct_ShouldReturnCorrectStatusCode()
        {

            var orderRequest = GenerateOrderRequestFromJson("OrderWithValidBatchProduct.json");
            var orderResponse = await CreateOrder(orderRequest);

            ValidateOrder(orderRequest, orderResponse);

            var fulfillmentRequest = GenerateFulfillmentRequest(orderResponse);
            var fulfillmentResponse = await AcceptFulfillment(fulfillmentRequest);

            ValidateFullfilment(fulfillmentResponse);

            var shipmentRequest = GenerateShipmentRequest(orderResponse);
            var shipmentResponse = await CreateShipment(shipmentRequest);

            ValidateShipment(shipmentResponse);

            var completedOrder = await GetCompletedOrder(orderResponse);

            ValidateCompletedOrder(completedOrder);
        }

        private Order_Request GenerateOrderRequestFromJson(string fileName)
        {
            var orderRequest = RequestDeserializer.Deserialize<Order_Request>(fileName);
            orderRequest.order_number = $"Order{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8)}";
            orderRequest.order_date = DateTime.Now;
            return orderRequest;
        }

        private async Task<IRestResponse<Order_Response>> CreateOrder(Order_Request orderRequest)
        {
            var orderService = new OrderService();
            return await orderService.CreateOrder(Shops.TestShop_Id, orderRequest);
            
        }

        private void ValidateOrder(Order_Request orderRequest, IRestResponse<Order_Response> orderResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, orderResponse.StatusCode, orderResponse.Content.ToString());
            Assert.AreEqual(orderRequest.order_priority, orderResponse.Data.order_priority);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.In_Fullfilment), orderResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Finecom), orderResponse.Data.fulfillments[0].warehouse.name);
            Assert.AreEqual("automationbatch", orderResponse.Data.order_items[0].custom_attributes[0].attribute_value);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[0].state);
        }

        private List<Fulfillment_Request> GenerateFulfillmentRequest(IRestResponse<Order_Response> orderResponse)
        {
            return new List<Fulfillment_Request>() { new Fulfillment_Request() { fulfillment_id = orderResponse.Data.fulfillments[0].id } };
        }

        private async Task<IRestResponse<Fulfillment_Response>> AcceptFulfillment(List<Fulfillment_Request> fulfillment)
        {
            var fulfillmentService = new FulfillmentsService();
            return await fulfillmentService.FulfillmentsAction(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, fulfillment);
        }

        private void ValidateFullfilment(IRestResponse<Fulfillment_Response> fulfillmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, fulfillmentResponse.StatusCode, fulfillmentResponse.Content.ToString());
            Assert.IsNotNull(fulfillmentResponse.Data.success);
        }

        private Shipment_Request GenerateShipmentRequest(IRestResponse<Order_Response> orderResponse)
        {
            return new Shipment_Request()
            {
                carrier_id = Carriers.DHL_Id,
                order_number = orderResponse.Data.order_number,
                shipment_date = DateTime.Now.AddDays(7),
                shipment_items = new List<ShipmentItem_S>() {
                    new ShipmentItem_S {
                        product = new ProductShipment() {
                            sku = orderResponse.Data.order_items[0].product.sku },
                    quantity = orderResponse.Data.order_items[0].quantity,
                    shipped_batches = new List<ShippedBatch_S> { new ShippedBatch_S() {
                        batch = "MB",
                        quantity = orderResponse.Data.order_items[0].quantity,
                        sku = orderResponse.Data.order_items[0].product.sku } }
                    } },
                tracking_codes = new List<string>() { "automation1", "automation2" },
                tracking_urls = new List<string>() { "tracking.com/automation1", "tracking.com/automation2" }
            };
        }

        private async Task<IRestResponse<Shipment_Response>> CreateShipment(Shipment_Request shipment)
        {
            var shipmentService = new ShipmentService();
            return await shipmentService.CreateShipment(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, shipment);           
        }

        private void ValidateShipment(IRestResponse<Shipment_Response> shipmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, shipmentResponse.StatusCode, shipmentResponse.Content.ToString());
            Assert.AreEqual(false, shipmentResponse.Data.forwarded_to_shop);
        }

        private async Task<IRestResponse<Order_Response>> GetCompletedOrder(IRestResponse<Order_Response> orderResponse)
        {
            var orderService = new OrderService();
            return await orderService.GetOrderById(Shops.TestShop_Id, orderResponse.Data.id);        
        }

        private void ValidateCompletedOrder(IRestResponse<Order_Response> completedOrder)
        {
            Assert.AreEqual(HttpStatusCode.OK, completedOrder.StatusCode, completedOrder.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Completed), completedOrder.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[0].state);
        }
        
    }
}
