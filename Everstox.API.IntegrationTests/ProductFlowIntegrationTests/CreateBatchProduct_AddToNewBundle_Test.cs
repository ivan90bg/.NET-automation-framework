using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Products;
using Everstox.API.Shop.Products.Models.Request_Models;
using Everstox.API.Shop.Products.Models.Response_Models;
using Everstox.API.Warehouses.Stocks;
using Everstox.API.Warehouses.Stocks.Models.Request_Models;
using Everstox.API.Warehouses.Stocks.Models.Response_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Everstox.API.IntegrationTests.ProductFlowIntegrationTests
{
    [TestClass]
    public class CreateBatchProduct_AddToNewBundle_Test
    {
        [TestMethod]
        public async Task CreateBatchProducts_AddToNewBundle_CreateStocksTest()
        {
            var firstBatchProductRequest = CreateFirstBatchProductRequest();
            var secondBatchProductRequest = CreateSecondBatchProductRequest();

            var firstBatchResponse = await CreateProduct(firstBatchProductRequest);

            ValidateProduct(firstBatchResponse);

            var secondBatchResponse = await CreateProduct(secondBatchProductRequest);

            ValidateProduct(secondBatchResponse);

            var firstBatchStockRequest = CreateStockRequestForFirstProduct(firstBatchProductRequest);
            var secondBatchStockRequest = CreateStockRequestForSecondProduct(secondBatchProductRequest);

            var firstStockResponse = await CreateStock(firstBatchStockRequest);
            ValidateStock(firstStockResponse);

            var secondStockResponse = await CreateStock(secondBatchStockRequest);
            ValidateStock(secondStockResponse);

            var bundleProduct = CreateBundleProductRequest(firstBatchProductRequest, secondBatchProductRequest);
            var bundleResponse = await CreateProduct(bundleProduct);

            ValidateProduct(bundleResponse);
        }

        private Product_Request CreateBundleProductRequest(Product_Request firstProductRequest, Product_Request secondProductRequest)
        {
            return new Product_Request()
            {
                bundle_product = true,
                bundles = new List<Bundle_P_Req>()
                {
                    new Bundle_P_Req() { product_sku = firstProductRequest.sku, quantity = 2 },
                    new Bundle_P_Req() { product_sku = secondProductRequest.sku, quantity = 2 }
                },
                color = "Multicolor",
                country_of_origin = "Finland",
                custom_attributes = new List<CustomAttribute_P_Req> { new CustomAttribute_P_Req() { attribute_key = "Wireless Charger included", attribute_value = "no" } },
                customs_code = "CS_code",
                customs_description = "CS_descr",
                name = $"AutomationBundle_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4)}",
                sku = $"AutomationSKU_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4)}",
                status = "active",
                units = new List<Unit_P_Req> { new Unit_P_Req() { default_unit = true, gtin = "Ericssons", name = "Pieces", height_in_cm = 60, length_in_cm = 60, width_in_cm = 60 } }

            };
        }

        private void ValidateStock(IRestResponse<Stock_Response> stockResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, stockResponse.StatusCode, stockResponse.Content.ToString());
        }

        private async Task<IRestResponse<Stock_Response>> CreateStock(Stock_Request stockRequest)
        {
            var stocksService = new StocksService();
            return await stocksService.CreateNewStock(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, stockRequest);
            
        }

        private Stock_Request CreateStockRequestForFirstProduct(Product_Request firstBatchProductRequest)
        {
            return new Stock_Request()
            {
                batch = new Batch_Req() { batch = "batch_2628", expiration_date = DateTime.Now.AddDays(30) },
                product = new Product_Stock() { shop_id = Shops.TestShop_Id, sku = firstBatchProductRequest.sku },
                quantity = 500
            };
        }

        private Stock_Request CreateStockRequestForSecondProduct(Product_Request secondBatchProductRequest)
        {
            return new Stock_Request()
            {
                batch = new Batch_Req() { batch = "batch_N68", expiration_date = DateTime.Now.AddDays(60) },
                product = new Product_Stock() { shop_id = Shops.TestShop_Id, sku = secondBatchProductRequest.sku },
                quantity = 500
            };
        }

        private void ValidateProduct(IRestResponse<Product_Response> productResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, productResponse.StatusCode, productResponse.Content.ToString());
        }

        private async Task<IRestResponse<Product_Response>> CreateProduct(Product_Request productRequest)
        {
            var productsService = new ProductsService();
            return await productsService.CreateProduct(Shops.TestShop_Id, productRequest);
           
        }

        private Product_Request CreateFirstBatchProductRequest()
        {
            return new Product_Request()
            {
                batch_product = true,
                color = "Black/Grey",
                country_of_origin = "Finland",
                custom_attributes = new List<CustomAttribute_P_Req> { new CustomAttribute_P_Req() { attribute_key = "Additional battery", attribute_value = "no" } },
                customs_code = "CS_code",
                customs_description = "CS_descr",
                name = $"AutomationName_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4)}",
                sku = $"FirstAutoBatch_{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 4)}",
                status = "active",
                units = new List<Unit_P_Req> { new Unit_P_Req() { default_unit = true, gtin = "N66-N00", name = "Piece", height_in_cm = 30, length_in_cm = 30, width_in_cm = 30 } }

            };
        }

        private Product_Request CreateSecondBatchProductRequest()
        {
            return new Product_Request()
            {
                batch_product = true,
                color = "Blue",
                country_of_origin = "Finland",
                custom_attributes = new List<CustomAttribute_P_Req> { new CustomAttribute_P_Req() { attribute_key = "Additional battery", attribute_value = "yes" } },
                customs_code = "CS_code",
                customs_description = "CS_descr",
                name = $"AutomationName_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4)}",
                sku = $"SecondAutoBatch_{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 4)}",
                status = "active",
                units = new List<Unit_P_Req> { new Unit_P_Req() { default_unit = true, gtin = "N33-N10", name = "Piece", height_in_cm = 20, length_in_cm = 20, width_in_cm = 30 } }

            };
        }
    } 
}
