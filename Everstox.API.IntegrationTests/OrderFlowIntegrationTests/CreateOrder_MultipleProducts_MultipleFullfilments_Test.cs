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
            var orderResponse = await CreateOrder(orderRequest);

            ValidateOrder(orderResponse);

            var fulfillment_1 = CreateFirstFulfillment(orderResponse);
            var fulfillment_2 = CreateSecondFulfillment(orderResponse);

            var fulfillment_1Response = await AcceptFirstFulfillment(fulfillment_1);

            ValidateFulfillment(fulfillment_1Response);

            var fulfillment_2Response = await AcceptSecondFulfillment(fulfillment_2);

            ValidateFulfillment(fulfillment_2Response);

            var shipment_1 = CreateFirstShipment(orderResponse);
            var shipment_2 = CreateSecondShipment(orderResponse);

            var shipment_1Response = await SendFirstShipment(shipment_1);

            ValidateShipment(shipment_1Response);

            var shipment_2Response = await SendSecondShipment(shipment_2);

            ValidateShipment(shipment_2Response);

            var completedOrder = await GetCompletedOrder(orderResponse);

            ValidateCompletedOrder(completedOrder);
        }

       

        private Order_Request GenerateOrderRequestFromJson(string fileName)
        {
            var orderRequest = RequestDeserializer.Deserialize<Order_Request>(fileName);
            orderRequest.order_number = $"Order{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6)}";
            orderRequest.order_date = DateTime.Now;
            return orderRequest;
        }

        private async Task<IRestResponse<Order_Response>> CreateOrder(Order_Request orderRequest)
        {
            var orderService = new OrderService();
            return await orderService.CreateOrder(Shops.TestShop_Id, orderRequest);
        }

        private void ValidateOrder(IRestResponse<Order_Response> orderResponse)
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

        private List<Fulfillment_Request> CreateSecondFulfillment(IRestResponse<Order_Response> orderResponse)
        {
            return new List<Fulfillment_Request>() { new Fulfillment_Request() { fulfillment_id = orderResponse.Data.fulfillments[1].id } };
        }

        private List<Fulfillment_Request> CreateFirstFulfillment(IRestResponse<Order_Response> orderResponse)
        {
            return new List<Fulfillment_Request>() { new Fulfillment_Request() { fulfillment_id = orderResponse.Data.fulfillments[0].id } };
        }

        private async Task<IRestResponse<Fulfillment_Response>> AcceptFirstFulfillment(List<Fulfillment_Request> fulfillment)
        {
            var fulfillmentService = new FulfillmentsService();
            return await fulfillmentService.FulfillmentsAction(WarehousesData.BolecWarehouse_Id, WarehousesData.BolecWarehouse_Connector, fulfillment);
        }

        private async Task<IRestResponse<Fulfillment_Response>> AcceptSecondFulfillment(List<Fulfillment_Request> fulfillment)
        {
            var fulfillmentService = new FulfillmentsService();
            return await fulfillmentService.FulfillmentsAction(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, fulfillment);
        }

        private void ValidateFulfillment(IRestResponse<Fulfillment_Response> fulfillment_Response)
        {
            Assert.AreEqual(HttpStatusCode.OK, fulfillment_Response.StatusCode, fulfillment_Response.Content.ToString());
            Assert.IsNotNull(fulfillment_Response.Data.success);
        }

        private Shipment_Request CreateFirstShipment(IRestResponse<Order_Response> orderResponse)
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

        private Shipment_Request CreateSecondShipment(IRestResponse<Order_Response> orderResponse)
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

        private async Task<IRestResponse<Shipment_Response>> SendFirstShipment(Shipment_Request shipment)
        {
            var shipmentService = new ShipmentService();
            return await shipmentService.CreateShipment(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, shipment);
        }

        private async Task<IRestResponse<Shipment_Response>> SendSecondShipment(Shipment_Request shipment)
        {
            var shipmentsService = new ShipmentService();
            return await shipmentsService.CreateShipment(WarehousesData.BolecWarehouse_Id, WarehousesData.BolecWarehouse_Connector, shipment);
        }

        private void ValidateShipment(IRestResponse<Shipment_Response> shipment_Response)
        {
            Assert.AreEqual(HttpStatusCode.Created, shipment_Response.StatusCode, shipment_Response.Content.ToString());
            Assert.AreEqual(false, shipment_Response.Data.forwarded_to_shop);
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
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[1].state);
        }

    }
}
