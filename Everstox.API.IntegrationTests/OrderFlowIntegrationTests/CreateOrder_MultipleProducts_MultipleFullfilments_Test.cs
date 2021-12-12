using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Orders;
using Everstox.API.Shop.Orders.Models.Request_Models;
using Everstox.API.Warehouses.Fulfillments;
using Everstox.API.Warehouses.Fulfillments.Models.Request_Model;
using Everstox.API.Warehouses.Shipments;
using Everstox.API.Warehouses.Shipments.Models.Request_Models;
using Everstox.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [DeploymentItem(@"C:\Users\Ivan\.NET Projects\Everstox\Everstox.API.IntegrationTests\Test_Data\OrderWithMultipleFulfillments.json")]
        [TestMethod]
        public async Task CreateOrder_WithProvidedFileWithMultipleFulfillments_ShouldReturnCorrectStatusCode()
        {
            // Read order from a json file
            var orderRequest = RequestDeserializer.Deserialize<Order_Request>("OrderWithMultipleFulfillments.json");
            orderRequest.order_number = $"Order - {Guid.NewGuid()}";
            orderRequest.order_date = DateTime.Now;

            // Create order
            var orderService = new OrderService();
            var orderResponse = await orderService.CreateOrder(Shops.TestShop_Id, orderRequest);

            // Order validations
            Assert.AreEqual(HttpStatusCode.Created, orderResponse.StatusCode, orderResponse.Content.ToString());
            Assert.AreEqual(orderRequest.order_priority, orderResponse.Data.order_priority);
            Assert.AreEqual(orderRequest.order_number, orderResponse.Data.order_number);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.In_Fullfilment), orderResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Bolec_Warehouse), orderResponse.Data.fulfillments[0].warehouse.name);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Finecom), orderResponse.Data.fulfillments[1].warehouse.name);
            Assert.AreEqual("shipping_note", orderResponse.Data.custom_attributes[0].attribute_key);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[0].state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[1].state);
            Assert.AreEqual("Dashboard manual (B2C)", orderResponse.Data.shop_instance.name);

            // Create fulfillments
            var fulfillment_1 = new List<Fulfillment_Request>() { new Fulfillment_Request() { fulfillment_id = orderResponse.Data.fulfillments[0].id } };
            var fulfillment_2 = new List<Fulfillment_Request>() { new Fulfillment_Request() { fulfillment_id = orderResponse.Data.fulfillments[1].id } };

            // Accept first fulfillment
            var fulfillmentService = new FulfillmentsService();
            var fulfillment_1Response = await fulfillmentService.FulfillmentsAction(WarehousesData.BolecWarehouse_Id, WarehousesData.BolecWarehouse_Connector, fulfillment_1);

            // First fulfillment validations
            Assert.AreEqual(HttpStatusCode.OK, fulfillment_1Response.StatusCode, fulfillment_1Response.Content.ToString());
            Assert.IsNotNull(fulfillment_1Response.Data.success);

            // Accept second fulfillment
            var fulfillment_2Response = await fulfillmentService.FulfillmentsAction(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, fulfillment_2);

            // Second fulfillment validations
            Assert.AreEqual(HttpStatusCode.OK, fulfillment_2Response.StatusCode, fulfillment_2Response.Content.ToString());
            Assert.IsNotNull(fulfillment_2Response.Data.success);

            // Create shipments
            var shipment_1 = new Shipment_Request()
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

            var shipment_2 = new Shipment_Request()
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

            // Send first shipment
            var shipmentService = new ShipmentService();
            var shipment_1Response = await shipmentService.CreateShipment(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, shipment_1);

            // First shipment validations
            Assert.AreEqual(HttpStatusCode.Created, shipment_1Response.StatusCode, shipment_1Response.Content.ToString());
            Assert.AreEqual(false, shipment_1Response.Data.forwarded_to_shop);

            // Send second shipment
            var shipment_2Response = await shipmentService.CreateShipment(WarehousesData.BolecWarehouse_Id, WarehousesData.BolecWarehouse_Connector, shipment_2);

            // Second shipment validations
            Assert.AreEqual(HttpStatusCode.Created, shipment_2Response.StatusCode, shipment_2Response.Content.ToString());
            Assert.AreEqual(false, shipment_2Response.Data.forwarded_to_shop);

            // Get completed order
            var completedOrder = await orderService.GetSingleOrder(Shops.TestShop_Id, orderResponse.Data.id);

            // Completed order validations
            Assert.AreEqual(HttpStatusCode.OK, completedOrder.StatusCode, completedOrder.Content.ToString());
            Assert.AreEqual("completed", completedOrder.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[0].state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[1].state);
        }
    }
}
