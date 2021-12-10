using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Orders;
using Everstox.API.Shop.Orders.Models.Request_Models;
using Everstox.API.Warehouses.Fulfillments;
using Everstox.API.Warehouses.Fulfillments.Models.Request_Model;
using Everstox.API.Warehouses.Shipments;
using Everstox.API.Warehouses.Shipments.Models.Request_Models;
using Everstox.Infrastructure;
using Everstox.Infrastructure.Infrastructure_Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static Everstox.Infrastructure.Infrastructure_Data.EverstoxAPIData;

namespace Everstox.API.IntegrationTests
{
    [TestClass]
    public class OrdersIntegrationTests
    {
        [DeploymentItem(@"C:\Users\Ivan\.NET Projects\Everstox\Everstox.API.IntegrationTests\Test_Data\CreateOrderSingleFulfillment.json")]
        [TestMethod]
        public async Task CreateOrder_WithProvidedFileSampleOrder_ShouldReturnCorrectStatusCode()
        {
            // Read order from a json file
            var orderRequest = RequestDeserializer.Deserialize<Order_Creation_Model>("CreateOrderSingleFulfillment.json");
            orderRequest.order_number = $"Order - {Guid.NewGuid()}";
            orderRequest.order_date = DateTime.Now;

            // Create order
            var orderService = new OrderService();
            var orderResponse = await orderService.CreateOrder(Shops.TestShop_Id, orderRequest);

            // Order validations
            Assert.AreEqual(HttpStatusCode.Created, orderResponse.StatusCode, orderResponse.Content.ToString());
            Assert.AreEqual(orderRequest.order_priority, orderResponse.Data.order_priority);
            Assert.AreEqual(orderRequest.order_number, orderResponse.Data.order_number);
            Assert.AreEqual(Fulfillment_State.In_Fullfilment.ToString(), orderResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Finecom), orderResponse.Data.fulfillments[0].warehouse.name);
            Assert.AreEqual("shipping_note", orderResponse.Data.custom_attributes[0].attribute_key);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[0].state);
            Assert.AreEqual("Dashboard manual (B2C)", orderResponse.Data.shop_instance.name);

            // Create fulfillment
            var fulfillment = new List<Fulfillment_Request_Model>() { new Fulfillment_Request_Model() { order_number = orderResponse.Data.order_number } };

            var fulfillmentService = new FulfillmentsService();
            var fulfillmentResponse = await fulfillmentService.FulfillmentsAction(WarehousesData.FinecomQA1_Id, "accept", WarehousesData.FinecomQA1_Connector, fulfillment);

            // Fulfillment validations
            Assert.AreEqual(HttpStatusCode.OK, fulfillmentResponse.StatusCode, fulfillmentResponse.Content.ToString());
            Assert.IsNotNull(fulfillmentResponse.Data.success);

            // Create shipment
            var shipment = NewMethod(orderResponse);

            var shipmentService = new ShipmentService();
            var shipmentResponse = await shipmentService.CreateShipment(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, shipment);

            // Shipment validations
            Assert.AreEqual(HttpStatusCode.Created, shipmentResponse.StatusCode, shipmentResponse.Content.ToString());
            Assert.AreEqual(false, shipmentResponse.Data.forwarded_to_shop);

            // Get completed order
            var completedOrder = await orderService.GetSingleOrder(Shops.TestShop_Id, orderResponse.Data.id);

            // Completed order validations
            Assert.AreEqual(HttpStatusCode.OK, completedOrder.StatusCode, completedOrder.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Completed), completedOrder.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[0].state);

        }

        private static Shipment_Creation_Model NewMethod(RestSharp.IRestResponse<Shop.Orders.Models.Response_Models.Order_Response_Model> orderResponse)
        {
            return new Shipment_Creation_Model()
            {
                carrier_id = Carriers.DHL_Id,
                fulfillment_id = orderResponse.Data.fulfillments[0].id,
                shipment_date = new DateTime(2021, 11, 29),
                shipment_items = new List<ShipmentItem>() {
                    new ShipmentItem {
                        product = new ProductShipment() {
                            sku = orderResponse.Data.order_items[0].product.sku },
                    quantity = orderResponse.Data.order_items[0].quantity } },
                tracking_code = "automationtrackingcode",
                tracking_codes = new List<string>() { "auto1", "auto2" },
                tracking_urls = new List<string>() { "automation tracking url" }
            };
        }

        [DeploymentItem(@"C:\Users\Ivan\.NET Projects\Everstox\Everstox.API.IntegrationTests\Test_Data\CreateOrderMultipleFulfillments.json")]
        [TestMethod]
        public async Task CreateOrder_WithProvidedFileWithMultipleFulfillments_ShouldReturnCorrectStatusCode()
        {
            // Read order from a json file
            var orderRequest = RequestDeserializer.Deserialize<Order_Creation_Model>("CreateOrderMultipleFulfillments.json");
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
            Assert.AreEqual("Bolec Warehouse", orderResponse.Data.fulfillments[0].warehouse.name);
            Assert.AreEqual("Finecom QA1", orderResponse.Data.fulfillments[1].warehouse.name);
            Assert.AreEqual("shipping_note", orderResponse.Data.custom_attributes[0].attribute_key);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[0].state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[1].state);
            Assert.AreEqual("Dashboard manual (B2C)", orderResponse.Data.shop_instance.name);

            // Create fulfillments
            var fulfillment_1 = new List<Fulfillment_Request_Model>() { new Fulfillment_Request_Model() { fulfillment_id = orderResponse.Data.fulfillments[0].id } };
            var fulfillment_2 = new List<Fulfillment_Request_Model>() { new Fulfillment_Request_Model() { fulfillment_id = orderResponse.Data.fulfillments[1].id } };

            // Accept first fulfillment
            var fulfillmentService = new FulfillmentsService();
            var fulfillment_1Response = await fulfillmentService.FulfillmentsAction(WarehousesData.BolecWarehouse_Id, "accept", WarehousesData.BolecWarehouse_Connector, fulfillment_1);

            // First fulfillment validations
            Assert.AreEqual(HttpStatusCode.OK, fulfillment_1Response.StatusCode, fulfillment_1Response.Content.ToString());
            Assert.IsNotNull(fulfillment_1Response.Data.success);

            // Accept second fulfillment
            var fulfillment_2Response = await fulfillmentService.FulfillmentsAction(WarehousesData.FinecomQA1_Id, "accept", WarehousesData.FinecomQA1_Connector, fulfillment_2);

            // Second fulfillment validations
            Assert.AreEqual(HttpStatusCode.OK, fulfillment_2Response.StatusCode, fulfillment_2Response.Content.ToString());
            Assert.IsNotNull(fulfillment_2Response.Data.success);

            // Create shipments
            var shipment_1 = new Shipment_Creation_Model()
            {
                carrier_id = Carriers.DHL_Id,
                order_number = orderResponse.Data.order_number,
                shipment_date = new DateTime(2021, 11, 29),
                shipment_items = new List<ShipmentItem>() {
                    new ShipmentItem {
                        product = new ProductShipment() {
                            sku = orderResponse.Data.order_items[0].product.sku },
                    quantity = orderResponse.Data.order_items[0].quantity } },
                tracking_code = "automationtrackingcode",
                tracking_codes = new List<string>() { "auto1", "auto2" },
                tracking_urls = new List<string>() { "automation tracking url" }
            };

            var shipment_2 = new Shipment_Creation_Model()
            {
                carrier_id = Carriers.UPS_Id,
                order_number = orderResponse.Data.order_number,
                shipment_date = new DateTime(2021, 11, 29),
                shipment_items = new List<ShipmentItem>() {
                    new ShipmentItem {
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

        [DeploymentItem(@"C:\Users\Ivan\.NET Projects\Everstox\Everstox.API.IntegrationTests\Test_Data\CreateOrderBatch.json")]
        [TestMethod]
        public async Task CreateOrder_WithBatchProduct_ShouldReturnCorrectStatusCode()
        {
            // Read order from a json file
            var orderRequest = RequestDeserializer.Deserialize<Order_Creation_Model>("CreateOrderBatch.json");
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
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Finecom), orderResponse.Data.fulfillments[0].warehouse.name);
            Assert.AreEqual("automationbatch", orderResponse.Data.order_items[0].custom_attributes[0].attribute_value);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.fulfillments[0].state);

            // Create fulfillments
            var fulfillment = new List<Fulfillment_Request_Model>() { new Fulfillment_Request_Model() { fulfillment_id = orderResponse.Data.fulfillments[0].id } };
           
            // Accept first fulfillment
            var fulfillmentService = new FulfillmentsService();
            var fulfillmentResponse = await fulfillmentService.FulfillmentsAction(WarehousesData.FinecomQA1_Id, "accept", WarehousesData.FinecomQA1_Connector, fulfillment);

            // First fulfillment validations
            Assert.AreEqual(HttpStatusCode.OK, fulfillmentResponse.StatusCode, fulfillmentResponse.Content.ToString());
            Assert.IsNotNull(fulfillmentResponse.Data.success);

            // Create shipments
            var shipment = new Shipment_Creation_Model()
            {
                carrier_id = Carriers.DHL_Id,
                order_number = orderResponse.Data.order_number,
                shipment_date = new DateTime(2021, 11, 29),
                shipment_items = new List<ShipmentItem>() {
                    new ShipmentItem {
                        product = new ProductShipment() {
                            sku = orderResponse.Data.order_items[0].product.sku },
                    quantity = orderResponse.Data.order_items[0].quantity,
                    shipped_batches = new List<ShippedBatch> { new ShippedBatch() {
                        batch = "MB",
                        quantity = orderResponse.Data.order_items[0].quantity,
                        sku = orderResponse.Data.order_items[0].product.sku } }
                    } },
                tracking_code = "automationtrackingcode",
                tracking_codes = new List<string>() { "auto1", "auto2" },
                tracking_urls = new List<string>() { "automation tracking url" }
            };

            // Send first shipment
            var shipmentService = new ShipmentService();
            var shipmentResponse = await shipmentService.CreateShipment(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, shipment);

            // First shipment validations
            Assert.AreEqual(HttpStatusCode.Created, shipmentResponse.StatusCode, shipmentResponse.Content.ToString());
            Assert.AreEqual(false, shipmentResponse.Data.forwarded_to_shop);

            // Get completed order
            var completedOrder = await orderService.GetSingleOrder(Shops.TestShop_Id, orderResponse.Data.id);

            // Completed order validations
            Assert.AreEqual(HttpStatusCode.OK, completedOrder.StatusCode, completedOrder.Content.ToString());
            Assert.AreEqual("completed", completedOrder.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Shipped), completedOrder.Data.fulfillments[0].state);
        }

    }
}