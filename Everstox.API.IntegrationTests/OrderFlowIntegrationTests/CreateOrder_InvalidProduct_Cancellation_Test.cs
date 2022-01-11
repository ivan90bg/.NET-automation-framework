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

            var orderRequest = GenerateOrderFromJson("OrderWithInvalidBatchProduct.json");
            var orderResponse = await CreateOrder(orderRequest);

            ValidateOrder(orderResponse);

            var productRequest = GenerateProductRequest(orderRequest);
            var productResponse = await CreateProduct(productRequest);

            ValidateProduct(productResponse);

            var stockRequest = GenerateStockRequest(productRequest);
            var stockResponse = await CreateStock(stockRequest);

            ValidateStock(stockResponse);

            var lastImportResponse = await ReturnLastImport();
            var reprocessedImport = await ReprocessLastImport(lastImportResponse);

            ValidateImport(reprocessedImport);

            var fulfillmentRequest = GenerateFulfillmentRequest(orderRequest);
            var fulfillmentResponse = await AcceptFulfillment(fulfillmentRequest);

            ValidateFulfillment(fulfillmentResponse);

            var lastOrderResponse = await GetLastOrder(orderRequest);

            var shipmentRequest = GenerateShipmentRequest(lastOrderResponse);
            var shipmentResponse = await CreateShipment(shipmentRequest);

            ValidateShipment(shipmentResponse);

            var cancelResponse = await CancelOrder(lastOrderResponse);
            ValidateCancellation(cancelResponse);

            var completedOrder = await GetCompletedOrder(orderRequest);
            ValidateCompletedOrder(completedOrder);

        }

        private Order_Request GenerateOrderFromJson(string fileName)
        {
            var orderRequest = RequestDeserializer.Deserialize<Order_Request>(fileName);
            orderRequest.order_number = $"Order{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8)}";
            orderRequest.order_date = DateTime.Now;
            orderRequest.order_items[0].product.sku = $"SKU_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4)}";

            return orderRequest;
        }

        private async Task<IRestResponse<Order_Response>> CreateOrder(Order_Request orderRequest)
        {
            var orderService = new OrderService();
            return await orderService.CreateOrder(Shops.TestShop_Id, orderRequest);            
        }

        private void ValidateOrder(IRestResponse<Order_Response> orderResponse)
        {
            Assert.AreEqual(HttpStatusCode.Accepted, orderResponse.StatusCode, orderResponse.Content.ToString());
        }

        private Product_Request GenerateProductRequest(Order_Request orderRequest)
        {
            return new Product_Request()
            {
                batch_product = true,
                color = "Metallic black",
                country_of_origin = "Ireland",
                customs_code = "IrishTaxCode1",
                customs_description = "Custom descr",
                name = $"Automation_{new Random().Next(100, 1000)}",
                size = "L",
                sku = orderRequest.order_items[0].product.sku,
                status = "active",
                units = new List<Unit_P_Req> { new Unit_P_Req() {
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

        private async Task<IRestResponse<Product_Response>> CreateProduct(Product_Request productRequest)
        {
            var productService = new ProductsService();
            return await productService.CreateProduct(Shops.TestShop_Id, productRequest);
            
        }

        private void ValidateProduct(IRestResponse<Product_Response> productResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, productResponse.StatusCode, productResponse.Content.ToString());
        }

        private Stock_Request GenerateStockRequest(Product_Request productRequest)
        {
            return new Stock_Request()
            {
                batch = new Batch_Req()
                {
                    batch = "AutomationBatch",
                    expiration_date = DateTime.Now.AddDays(31),
                },

                product = new Product_Stock()
                {
                    shop_id = Shops.TestShop_Id,
                    sku = productRequest.sku
                },

                quantity = 500

            };
        }

        private async Task<IRestResponse<Stock_Response>> CreateStock(Stock_Request stockRequest)
        {
            var stockService = new StocksService();
            return await stockService.CreateNewStock(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, stockRequest);
            
        }

        private void ValidateStock(IRestResponse<Stock_Response> stockResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, stockResponse.StatusCode, stockResponse.Content.ToString());
        }

        private async Task<IRestResponse<Import_Response>> ReturnLastImport()
        {
            var importService = new ImportsService();
            return await importService.ReturnLastImportId();
        }

        private async Task<IRestResponse<Import_Response>> ReprocessLastImport(IRestResponse<Import_Response> import)
        {
            var importService = new ImportsService();
            return await importService.ImportsActions(import.Data.items[0].id);
            
        }

        private void ValidateImport(IRestResponse<Import_Response> importResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, importResponse.StatusCode, importResponse.Content.ToString());
        }

        private List<Fulfillment_Request> GenerateFulfillmentRequest(Order_Request orderRequest)
        {
            return new List<Fulfillment_Request>() { new Fulfillment_Request() { order_number = orderRequest.order_number } };
        }

        private async Task<IRestResponse<Fulfillment_Response>> AcceptFulfillment(List<Fulfillment_Request> fulfillment)
        {
            var fulfillmentService = new FulfillmentsService();
            return await fulfillmentService.FulfillmentsAction(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, fulfillment);
            
        }

        private void ValidateFulfillment(IRestResponse<Fulfillment_Response> fulfillmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, fulfillmentResponse.StatusCode, fulfillmentResponse.Content.ToString());
        }

        private async Task<IRestResponse<OrderList_Response>> GetLastOrder(Order_Request orderRequest)
        {
            var order = new OrderService();
            return await order.GetOrderByNumber(Shops.TestShop_Id, orderRequest.order_number);
            
        }

        private Shipment_Request GenerateShipmentRequest(IRestResponse<OrderList_Response> lastOrderResponse)
        {
            return new Shipment_Request()
            {

                carrier_id = Carriers.DHL_Id,
                fulfillment_id = lastOrderResponse.Data.items[0].fulfillments[0].id,
                shipment_date = DateTime.Now.AddDays(7),
                shipment_items = new List<ShipmentItem_S>() {
                    new ShipmentItem_S {
                        product = new ProductShipment() {
                            sku = lastOrderResponse.Data.items[0].order_items[0].product.sku },
                    quantity = lastOrderResponse.Data.items[0].order_items[0].quantity - 1 } },
                tracking_codes = new List<string>() { "automation1", "automation2" },
                tracking_urls = new List<string>() { "tracking.com/automation1", "tracking.com/automation2" }
            };
        }

        private async Task<IRestResponse<Shipment_Response>> CreateShipment(Shipment_Request shipment)
        {
            var shipmentService = new ShipmentService();
            return await shipmentService.CreateShipment(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, shipment);
            
        }

        private void ValidateShipment(IRestResponse<Shipment_Response> shipmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, shipmentResponse.StatusCode, shipmentResponse.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Partially_shipped), shipmentResponse.Data.shipment_items[0].fulfillment_item.state, shipmentResponse.Content.ToString());
        }

        private async Task<IRestResponse> CancelOrder(IRestResponse<OrderList_Response> lastOrderResponse)
        {
            var orderCancelRequest = new OrderCancel_Request();
            var orderService = new OrderService();
            return await orderService.CancelOrder(Shops.TestShop_Id, lastOrderResponse.Data.items[0].id, orderCancelRequest);
            
        }

        private void ValidateCancellation(IRestResponse cancelResponse)
        {
            Assert.AreEqual(HttpStatusCode.OK, cancelResponse.StatusCode, cancelResponse.Content.ToString());
        }

        private async Task<IRestResponse<OrderList_Response>> GetCompletedOrder(Order_Request orderRequest)
        {
            var orderService = new OrderService();
            return await orderService.GetOrderByNumber(Shops.TestShop_Id, orderRequest.order_number);
        }

        private void ValidateCompletedOrder(IRestResponse<OrderList_Response> completedOrder)
        {
            Assert.AreEqual(EnumString.GetStringValue(Fulfillment_State.Canceled), completedOrder.Data.items[0].state);
        }      


    }
}