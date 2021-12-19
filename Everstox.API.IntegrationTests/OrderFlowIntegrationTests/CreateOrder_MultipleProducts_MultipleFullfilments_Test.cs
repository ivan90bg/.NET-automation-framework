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
    public class CreateOrder_MultipleProducts_MultipleFullfilments_Test
    {
        [DeploymentItem(".\\Test_Data\\")]
        [TestMethod]
        public async Task CreateOrder_WithProvidedFileWithMultipleFulfillments_ShouldReturnCorrectStatusCode()
        {
            var orderRequest = GenerateOrderRequestFromJson("OrderWithMultipleFulfillments.json");

            var orderService = new OrderService();
            var orderResponse = await orderService.CreateOrder(Shops.TestShop_Id, orderRequest);

            OrderValidations(orderResponse);

            var fulfillment_1 = CreateFirsFulfillment(orderResponse);
            var fulfillment_2 = CreateSecondFulfillment(orderResponse);

            // Accept first fulfillment
            var fulfillmentService = new FulfillmentsService();
            var fulfillment_1Response = await fulfillmentService.FulfillmentsAction(WarehousesData.BolecWarehouse_Id, WarehousesData.BolecWarehouse_Connector, fulfillment_1);

            FulfillmentValidations(fulfillment_1Response);

            // Accept second fulfillment
            var fulfillment_2Response = await fulfillmentService.FulfillmentsAction(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, fulfillment_2);

            FulfillmentValidations(fulfillment_2Response);

            var shipment_1 = GenerateFirstShipment(orderResponse);
            var shipment_2 = GenerateSecondShipment(orderResponse);

            // Send first shipment
            var shipmentService = new ShipmentService();
            var shipment_1Response = await shipmentService.CreateShipment(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, shipment_1);

            ShipmentValidations(shipment_1Response);

            // Send second shipment
            var shipment_2Response = await shipmentService.CreateShipment(WarehousesData.BolecWarehouse_Id, WarehousesData.BolecWarehouse_Connector, shipment_2);

            ShipmentValidations(shipment_2Response);

            var completedOrder = await GetCompletedOrder(orderService, orderResponse);

            CompletedOrderValidations(completedOrder);
        }

        private static void CompletedOrderValidations(IRestResponse<Order_Response> completedOrder)
        {
            Assert.AreEqual(HttpStatusCode.OK, completedOrder.StatusCode, completedOrder.Content.ToString());
            Assert.AreEqual("completed", completedOrder.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[0].state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[1].state);
        }

        private static async Task<IRestResponse<Order_Response>> GetCompletedOrder(OrderService orderService, IRestResponse<Order_Response> orderResponse)
        {
            return await orderService.GetSingleOrder(Shops.TestShop_Id, orderResponse.Data.id);
        }

        private static void ShipmentValidations(IRestResponse<Shipment_Response> shipment_1Response)
        {
            Assert.AreEqual(HttpStatusCode.Created, shipment_1Response.StatusCode, shipment_1Response.Content.ToString());
            Assert.AreEqual(false, shipment_1Response.Data.forwarded_to_shop);
        }

        private static Shipment_Request GenerateSecondShipment(IRestResponse<Order_Response> orderResponse)
        {
            return new Shipment_Request()
            {
                carrier_id = Carriers.UPS_Id,
                order_number = orderResponse.Data.order_number,
                shipment_date = new DateTime(2021, 11, 29),
                shipment_items = new List<ShipmentItem_S>() {
                    new ShipmentItem_S {
                        product = new ProductShipment() {
                            sku = orderResponse.Data.order_items[1].product.sku },
                    quantity = orderResponse.Data.order_items[1].quantity } },
                tracking_code = "automationtrackingcode",
                tracking_codes = new List<string>() { "auto1", "auto2" },
                tracking_urls = new List<string>() { "automation tracking url" }
            };
        }

        private static Shipment_Request GenerateFirstShipment(IRestResponse<Order_Response> orderResponse)
        {
            return new Shipment_Request()
            {
                carrier_id = Carriers.DHL_Id,
                order_number = orderResponse.Data.order_number,
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

        private static void FulfillmentValidations(IRestResponse<Fulfillment_Response> fulfillment_1Response)
        {
            Assert.AreEqual(HttpStatusCode.OK, fulfillment_1Response.StatusCode, fulfillment_1Response.Content.ToString());
            Assert.IsNotNull(fulfillment_1Response.Data.success);
        }

        private static List<Fulfillment_Request> CreateSecondFulfillment(IRestResponse<Order_Response> orderResponse)
        {
            return new List<Fulfillment_Request>() { new Fulfillment_Request() { fulfillment_id = orderResponse.Data.fulfillments[1].id } };
        }

        private static List<Fulfillment_Request> CreateFirsFulfillment(IRestResponse<Order_Response> orderResponse)
        {
            return new List<Fulfillment_Request>() { new Fulfillment_Request() { fulfillment_id = orderResponse.Data.fulfillments[0].id } };
        }

        private static Order_Request GenerateOrderRequestFromJson(string fileName)
        {
            var orderRequest = RequestDeserializer.Deserialize<Order_Request>(fileName);
            orderRequest.order_number = $"Order{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6)}";
            orderRequest.order_date = DateTime.Now;
            return orderRequest;
        }

        private static void OrderValidations(IRestResponse<Order_Response> orderResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, orderResponse.StatusCode, orderResponse.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.In_Fullfilment), orderResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Bolec_Warehouse), orderResponse.Data.fulfillments[0].warehouse.name);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Finecom), orderResponse.Data.fulfillments[1].warehouse.name);
            Assert.AreEqual("shipping_note", orderResponse.Data.custom_attributes[0].attribute_key);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[0].state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[1].state);
            Assert.AreEqual("Dashboard manual (B2C)", orderResponse.Data.shop_instance.name);
        }
    }
}
