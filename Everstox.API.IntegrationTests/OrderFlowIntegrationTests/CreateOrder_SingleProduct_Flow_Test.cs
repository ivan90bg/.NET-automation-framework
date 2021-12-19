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
    public class CreateOrder_SingleProduct_Flow_Test
    {
        [DeploymentItem(".\\Test_Data\\")]
        [TestMethod]
        public async Task CreateOrder_SingleOrderItem_Flow_ShouldReturnCorrectStatusCode()
        {
            var orderRequest = GenerateOrderRequest("OrderWithSingleFulfillment.json");
            var orderResponse = await OrderCreation(orderRequest);

            OrderValidations(orderRequest, orderResponse);

            var fulfillment = GenerateFulfillment(orderResponse);
            var fulfillmentResponse = await FulfillmentAcceptance(fulfillment);

            FulfillmentValidations(fulfillmentResponse);

            var shipment = GenerateShipmentRequest(orderResponse);

            var shipmentResponse = await ShippmentCreation(shipment);

            ShipmentValidations(shipmentResponse);

            var completedOrder = await GetCompletedOrder(orderResponse);

            CompletedOrderValidations(completedOrder);

        }

        private static void CompletedOrderValidations(IRestResponse<Order_Response> completedOrder)
        {
            Assert.AreEqual(HttpStatusCode.OK, completedOrder.StatusCode, completedOrder.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Completed), completedOrder.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[0].state);
        }

        private static async Task<IRestResponse<Order_Response>> GetCompletedOrder(IRestResponse<Order_Response> orderResponse)
        {
            var orderService = new OrderService();
            var completedOrder = await orderService.GetSingleOrder(Shops.TestShop_Id, orderResponse.Data.id);
            return completedOrder;
        }

        private static void ShipmentValidations(IRestResponse<Shipment_Response> shipmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, shipmentResponse.StatusCode, shipmentResponse.Content.ToString());
            Assert.AreEqual(false, shipmentResponse.Data.forwarded_to_shop);
        }

        private static async Task<IRestResponse<Shipment_Response>> ShippmentCreation(Shipment_Request shipment)
        {
            var shipmentService = new ShipmentService();
            var shipmentResponse = await shipmentService.CreateShipment(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, shipment);
            return shipmentResponse;
        }

        private static void FulfillmentValidations(IRestResponse<Fulfillment_Response> fulfillmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, fulfillmentResponse.StatusCode, fulfillmentResponse.Content.ToString());
            Assert.IsNotNull(fulfillmentResponse.Data.success);
        }

        private static async Task<IRestResponse<Fulfillment_Response>> FulfillmentAcceptance(List<Fulfillment_Request> fulfillment)
        {
            var fulfillmentService = new FulfillmentsService();
            var fulfillmentResponse = await fulfillmentService.FulfillmentsAction(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, fulfillment);
            return fulfillmentResponse;
        }

        private static List<Fulfillment_Request> GenerateFulfillment(IRestResponse<Order_Response> orderResponse)
        {
            return new List<Fulfillment_Request>() { new Fulfillment_Request() { order_number = orderResponse.Data.order_number } };
        }

        private static void OrderValidations(Order_Request orderRequest, IRestResponse<Order_Response> orderResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, orderResponse.StatusCode, orderResponse.Content.ToString());
            Assert.AreEqual(orderRequest.order_priority, orderResponse.Data.order_priority);
            Assert.AreEqual(orderRequest.order_number, orderResponse.Data.order_number);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.In_Fullfilment), orderResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Finecom), orderResponse.Data.fulfillments[0].warehouse.name);
            Assert.AreEqual("shipping_note", orderResponse.Data.custom_attributes[0].attribute_key);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[0].state);
            Assert.AreEqual("Dashboard manual (B2C)", orderResponse.Data.shop_instance.name);
        }

        private static Order_Request GenerateOrderRequest(string fileName)
        {
            var orderRequest = RequestDeserializer.Deserialize<Order_Request>(fileName);
            orderRequest.order_number = $"Order{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6)}";
            orderRequest.order_date = DateTime.Now;
            return orderRequest;
        }

        private static async Task<IRestResponse<Order_Response>> OrderCreation(Order_Request? orderRequest)
        {
            var orderService = new OrderService();
            var orderResponse = await orderService.CreateOrder(Shops.TestShop_Id, orderRequest);
            return orderResponse;
        }

        private static Shipment_Request GenerateShipmentRequest(IRestResponse<Order_Response> orderResponse)
        {
            return new Shipment_Request()
            {
                carrier_id = Carriers.DHL_Id,
                fulfillment_id = orderResponse.Data.fulfillments[0].id,
                shipment_date = new DateTime(2021, 11, 29),
                shipment_items = new List<ShipmentItem_S>() {
                    new ShipmentItem_S {
                        product = new ProductShipment() {
                            sku = orderResponse.Data.order_items[0].product.sku },
                    quantity = orderResponse.Data.order_items[0].quantity } },
                tracking_code = "automationtrackingcode",
                tracking_codes = new List<string>() { "auto1", "auto2" },
                tracking_urls = new List<string>() { "automation tracking url" }
            };
        }
    }
}
