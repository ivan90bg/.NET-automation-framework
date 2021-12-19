using Everstox.API.Admin.Imports;
using Everstox.API.Admin.Imports.Models.Response_Models;
using Everstox.API.IntegrationTests.Static_Data;
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
using static Everstox.Infrastructure.Infrastructure_Data.EverstoxAPIData;

namespace Everstox.API.IntegrationTests.OrderFlowIntegrationTests
{
    [TestClass]
    public class CreateOrder_InvalidProduct_Cancellation_Test
    {
        [DeploymentItem(".\\Test_Data\\")]
        [TestMethod]
        public async Task CreateOrder_InvalidBatch_CreateBatch_PartialShipment_Cancellation_Test()
        {

            var orderRequest = GenerateOrderFromJsonFile("OrderWithInvalidBatchProduct.json");
            var orderResponse = await OrderCreation(orderRequest);

            OrderValidations(orderResponse);

            var productRequest = GenerateProductRequest(orderRequest);
            var productResponse = await ProductCreation(productRequest);

            ProductValidations(productResponse);

            var stockRequest = GenerateStockRequest(productRequest);
            var stockResponse = await StockCreation(stockRequest);

            StockValidations(stockResponse);

            var importResponse = await ReprocessLastImport();

            ImportValidations(importResponse);

            var fulfillment = GenerateFulfillmentRequest(orderRequest);
            var fulfillmentResponse = await FulfillmentAcceptance(fulfillment);

            FulfillmentValidations(fulfillmentResponse);

            var order = new OrderService();
            var lastOrderResponse = await order.GetOrderByNumber(Shops.TestShop_Id, orderRequest.order_number);

            var shipment = GenerateShipmentRequest(lastOrderResponse);
            var shipmentResponse = await ShipmentCreation(shipment);

            ShipmentValidations(shipmentResponse);

            var cancelResponse = await OrderCancellation(order, lastOrderResponse);
            CancellationValidations(cancelResponse);

            var completedOrder = await GetCompletedOrder(orderRequest, order);
            CompletedOrderValidations(completedOrder);

        }

        private static void CompletedOrderValidations(IRestResponse<OrderList_Response> completedOrder)
        {
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Canceled), completedOrder.Data.items[0].state);
        }

        private static async Task<IRestResponse<OrderList_Response>> GetCompletedOrder(Order_Request orderRequest, OrderService order)
        {
            return await order.GetOrderByNumber(Shops.TestShop_Id, orderRequest.order_number);
        }

        private static void CancellationValidations(IRestResponse<object> cancelResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, cancelResponse.StatusCode, cancelResponse.Content.ToString());
        }

        private static async Task<IRestResponse<object>> OrderCancellation(OrderService order, IRestResponse<OrderList_Response> lastOrderResponse)
        {
            var orderCancelRequest = new OrderCancel_Request();
            var cancelResponse = await order.CancelOrder(Shops.TestShop_Id, lastOrderResponse.Data.items[0].id, orderCancelRequest);
            return cancelResponse;
        }

        private static Shipment_Request GenerateShipmentRequest(IRestResponse<OrderList_Response> lastOrderResponse)
        {
            return new Shipment_Request()
            {

                carrier_id = Carriers.DHL_Id,
                fulfillment_id = lastOrderResponse.Data.items[0].fulfillments[0].id,
                shipment_date = new DateTime(2021, 12, 29),
                shipment_items = new List<ShipmentItem_S>() {
                    new ShipmentItem_S {
                        product = new ProductShipment() {
                            sku = lastOrderResponse.Data.items[0].order_items[0].product.sku },
                    quantity = lastOrderResponse.Data.items[0].order_items[0].quantity - 1 } },              
                tracking_codes = new List<string>() { "auto1", "auto2" },
                tracking_urls = new List<string>() { "google.com/auto1", "google.com/auto2" }
            };
        }

        private static async Task<IRestResponse<Import_Response>> ReprocessLastImport()
        {
            var importService = new ImportsService();
            var import = await importService.ReturnLastImportId();

            var importResponse = await importService.ImportsActions(import.Data.items[0].id);
            return importResponse;
        }

        private static void ImportValidations(IRestResponse<Import_Response> importResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, importResponse.StatusCode, importResponse.Content.ToString());
        }

        private static void FulfillmentValidations(IRestResponse<Fulfillment_Response> fulfillmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, fulfillmentResponse.StatusCode, fulfillmentResponse.Content.ToString());
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
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Partially_shipped), shipmentResponse.Data.shipment_items[0].fulfillment_item.state, shipmentResponse.Content.ToString());
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

        private static Product_Request GenerateProductRequest(Order_Request orderRequest)
        {
            return new Product_Request()
            {
                batch_product = true,
                color = "Metallic black",
                country_of_origin = "Ireland",
                customs_code = "IrishTaxCode1",
                customs_description = "Custom descr",
                name = $"Automation - {new Random().Next(100, 1000)}",
                size = "L",
                sku = orderRequest.order_items[0].product.sku,
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
            orderRequest.order_number = $"Order{Guid.NewGuid().ToString().Replace("-", "").Substring(0,6)}";
            orderRequest.order_date = DateTime.Now;
            orderRequest.order_items[0].product.sku = $"SKU - {Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4)}";

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