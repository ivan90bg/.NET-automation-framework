using Everstox.API.Admin.Imports;
using Everstox.API.Admin.Imports.Models.Response_Models;
using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Fulfillments;
using Everstox.API.Shop.Orders;
using Everstox.API.Shop.Orders.Models.Request_Models;
using Everstox.API.Shop.Orders.Models.Response_Models;
using Everstox.API.Shop.Products;
using Everstox.API.Shop.Products.Models.Request_Models;
using Everstox.API.Shop.Products.Models.Response_Models;
using Everstox.API.Warehouses.Fulfillments;
using Everstox.API.Warehouses.Fulfillments.Models.Request_Model;
using Everstox.API.Warehouses.Fulfillments.Models.Response_Model;
using Everstox.API.Warehouses.Shipments;
using Everstox.API.Warehouses.Shipments.Models.Request_Models;
using Everstox.API.Warehouses.Shipments.Models.Response_Models;
using Everstox.API.Warehouses.Stocks;
using Everstox.API.Warehouses.Stocks.Models.Request_Models;
using Everstox.API.Warehouses.Stocks.Models.Response_Models;
using Everstox.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Everstox.API.IntegrationTests.OrderFlowIntegrationTests
{
    [TestClass]
    public class CreateOrder_InvalidProduct_Cancellation_Test
    {
        [DeploymentItem(@"C:\Users\Ivan\.NET Projects\Everstox\Everstox.API.IntegrationTests\Test_Data\OrderWithInvalidBatchProduct.json")]
        [TestMethod]
        public async Task CreateOrder_WithProvidedFileSampleOrder_ShouldReturnCorrectStatusCode()
        {

            var orderRequest = GenerateOrderFromJsonFile("OrderWithInvalidBatchProduct.json");
            var orderResponse = await OrderCreation(orderRequest);

            OrderValidations(orderResponse);

            var productRequest = GenerateProductRequest();
            var productResponse = await ProductCreation(productRequest);

            ProductValidations(productResponse);

            var stockRequest = GenerateStockRequest(productRequest);
            var stockResponse = await StockCreation(stockRequest);

            StockValidations(stockResponse);

            var importService = new ImportsService();
            var import = await importService.ReturnLastImportId();
            var importResponse = importService.ImportsActions(import.Data.items[0].id);

            ImportValidations(importResponse);

            var fulfillment = GenerateFulfillmentRequest(orderRequest);
            var fulfillmentResponse = await FulfillmentAcceptance(fulfillment);

            FulfillmentValidations(fulfillmentResponse);

            var order = new OrderService();
            var orderR = await order.GetOrderByNumber(Shops.TestShop_Id, orderRequest.order_number);

            var shipment = new Shipment_Request()
            {

                carrier_id = Carriers.DHL_Id,
                fulfillment_id = orderR.Data.fulfillments[0].id,
                shipment_date = new DateTime(2021, 12, 29),
                shipment_items = new List<ShipmentItem_S>() {
                    new ShipmentItem_S {
                        product = new ProductShipment() {
                            sku = orderR.Data.order_items[0].product.sku },
                    quantity = orderR.Data.order_items[0].quantity } },
                tracking_code = "automationtrackingcode",
                tracking_codes = new List<string>() { "auto1", "auto2" },
                tracking_urls = new List<string>() { "automation tracking url" }
            };
            var shipmentResponse = await ShipmentCreation(shipment);

            ShipmentValidations(shipmentResponse);

            var shopFulfillmentService = new ShopFulfillmentsService();
            var cancelFulfillment = await shopFulfillmentService.CancelFulfillment(Shops.TestShop_Id, orderR.Data.fulfillments[0].id);
        }

        private static void FulfillmentValidations(IRestResponse<Fulfillment_Response> fulfillmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, fulfillmentResponse.StatusCode, fulfillmentResponse.Content.ToString());
        }

        private static void ImportValidations(Task<IRestResponse<Import_Response>> importResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, importResponse.Status);
        }

        private static async Task<IRestResponse<Fulfillment_Response>> FulfillmentAcceptance(List<Fulfillment_Request> fulfillment)
        {
            var fulfillmentService = new FulfillmentsService();
            var fulfillmentResponse = await fulfillmentService.FulfillmentsAction(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, fulfillment);
            return fulfillmentResponse;
        }

        private static List<Fulfillment_Request> GenerateFulfillmentRequest(Order_Request orderRequest)
        {
            return new List<Fulfillment_Request>() { new Fulfillment_Request() { order_number = orderRequest.order_number } };
        }

        private static void ShipmentValidations(IRestResponse<Shipment_Response> shipmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, shipmentResponse.StatusCode, shipmentResponse.Content.ToString());
        }

        private static async Task<IRestResponse<Shipment_Response>> ShipmentCreation(Shipment_Request shipment)
        {
            var shipmentService = new ShipmentService();
            var shipmentResponse = await shipmentService.CreateShipment(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, shipment);
            return shipmentResponse;
        }

        private static void StockValidations(IRestResponse<Stock_Response> stockResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, stockResponse.StatusCode, stockResponse.Content.ToString());
        }

        private static void ProductValidations(IRestResponse<Product_Response> productResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, productResponse.StatusCode, productResponse.Content.ToString());
        }

        private static async Task<IRestResponse<Stock_Response>> StockCreation(Stock_Request stockRequest)
        {
            var stockService = new StocksService();
            var stockResponse = await stockService.CreateNewStock(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, stockRequest);
            return stockResponse;
        }

        private static Stock_Request GenerateStockRequest(Product_Request productRequest)
        {
            return new Stock_Request()
            {
                batch = new Batch_Req()
                {
                    batch = "firstBatch",
                    expiration_date = new DateTime(2021, 12, 31)
                },

                product = new Product_Stock()
                {
                    shop_id = Shops.TestShop_Id,
                    sku = productRequest.sku
                },

                quantity = 500

            };
        }

        private static async Task<IRestResponse<Product_Response>> ProductCreation(Product_Request productRequest)
        {
            var productService = new ProductsService();
            var productResponse = await productService.CreateProduct(Shops.TestShop_Id, productRequest);
            return productResponse;
        }

        private static Product_Request GenerateProductRequest()
        {
            return new Product_Request()
            {
                batch_product = true,
                color = "Metallic black",
                country_of_origin = "Ireland",
                customs_code = "IrishTaxCode1",
                customs_description = "Custom descr",
                name = "BatchProducAutomation",
                size = "L",
                sku = "autoBatch",
                status = "active",
                units = new List<Unit_Req> { new Unit_Req() {
                                                        default_unit = true,
                                                        gtin = "111-222-333",
                                                        height_in_cm = 30,
                                                        length_in_cm = 10,
                                                        name = "Bottle",
                                                        quantity_of_base_unit = 1,
                                                        weight_gross_in_kg = 1,
                                                        weight_net_in_kg = 0.8f,
                                                        width_in_cm = 5 }
                                       }

            };
        }

        private static void OrderValidations(IRestResponse<Order_Response> orderResponse)
        {
            Assert.AreEqual(HttpStatusCode.Accepted, orderResponse.StatusCode, orderResponse.Content.ToString());
        }

        private static Order_Request GenerateOrderFromJsonFile(string fileName)
        {
            var orderRequest = RequestDeserializer.Deserialize<Order_Request>(fileName);
            orderRequest.order_number = $"Order - {Guid.NewGuid()}";
            orderRequest.order_date = DateTime.Now;
            return orderRequest;
        }

        private static async Task<IRestResponse<Order_Response>> OrderCreation(Order_Request? orderRequest)
        {
            var orderService = new OrderService();
            var orderResponse = await orderService.CreateOrder(Shops.TestShop_Id, orderRequest);
            return orderResponse;
        }
    }
}