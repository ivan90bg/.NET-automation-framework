using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Products;
using Everstox.API.Shop.Products.Models.Request_Models;
using Everstox.API.Warehouses.Stocks;
using Everstox.API.Warehouses.Stocks.Models.Request_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var firstBatchProduct = new Product_Request()
            {
                batch_product = true,
                color = "Black/Grey",
                country_of_origin = "Finland",
                custom_attributes = new List<CustomAttribute> { new CustomAttribute() { attribute_key = "Additional battery", attribute_value = "no" } },
                customs_code = "CS_code",
                customs_description = "CS_descr",
                name = "Ericsson 2628",
                sku = "E2628",
                status = "active",
                units = new List<Unit_Req> { new Unit_Req() { default_unit = true, gtin = "N66-N00", name = "Piece", height_in_cm = 30, length_in_cm = 30, width_in_cm = 30 } }

            };

            var secondBatchProduct = new Product_Request()
            {
                batch_product = true,
                color = "Blue",
                country_of_origin = "Finland",
                custom_attributes = new List<CustomAttribute> { new CustomAttribute() { attribute_key = "Additional battery", attribute_value = "yes"} },
                customs_code = "CS_code",
                customs_description = "CS_descr",
                name = "Ericsson N68",
                sku = "EN68",
                status = "active",
                units = new List<Unit_Req> { new Unit_Req() {default_unit = true, gtin = "N33-N10", name = "Piece", height_in_cm = 20, length_in_cm = 20, width_in_cm = 30 } }

            };

            var productService = new ProductsService();
            var firstBatchResponse = await productService.CreateProduct(Shops.TestShop_Id, firstBatchProduct);

            Assert.AreEqual(HttpStatusCode.Created, firstBatchResponse.StatusCode, firstBatchResponse.Content.ToString());

            var secondBatchResponse = await productService.CreateProduct(Shops.TestShop_Id, secondBatchProduct);

            Assert.AreEqual(HttpStatusCode.Created, secondBatchResponse.StatusCode, secondBatchResponse.Content.ToString());

            var firstBatchStock = new Stock_Request()
            {
                batch = new Batch_Req() { batch = "batch_2628", expiration_date = new DateTime(2023, 01, 01)},
                product = new Product_Stock() { shop_id = Shops.TestShop_Id, sku = firstBatchProduct.sku },
                quantity = 500
            };

            var secondBatchStock = new Stock_Request()
            {
                batch = new Batch_Req() { batch = "batch_N68", expiration_date = new DateTime(2023, 01, 01) },
                product = new Product_Stock() { shop_id = Shops.TestShop_Id, sku = secondBatchProduct.sku },
                quantity = 500
            };

            var stocksService = new StocksService();

            var firstStockResponse = await stocksService.CreateNewStock(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, firstBatchStock);
            Assert.AreEqual(HttpStatusCode.Created, firstStockResponse.StatusCode, firstStockResponse.Content.ToString());

            var secondStockResponse = await stocksService.CreateNewStock(WarehousesData.FinecomQA1_Id, WarehousesData.FinecomQA1_Connector, secondBatchStock);
            Assert.AreEqual(HttpStatusCode.Created, secondStockResponse.StatusCode, secondStockResponse.Content.ToString());


            var bundleProduct = new Product_Request()
            {
                bundle_product = true,
                bundles = new List<Bundle>()
                {
                    new Bundle() { product_sku = firstBatchProduct.sku, quantity = 2 },
                    new Bundle() { product_sku = secondBatchProduct.sku, quantity = 2 }
                },
                color = "Multicolor",
                country_of_origin = "Finland",
                custom_attributes = new List<CustomAttribute> { new CustomAttribute() { attribute_key = "Wireless Charger included", attribute_value = "no" } },
                customs_code = "CS_code",
                customs_description = "CS_descr",
                name = "Mobile Phones bunde",
                sku = "MobileBundle",
                status = "active",
                units = new List<Unit_Req> { new Unit_Req() { default_unit = true, gtin = "Ericssons", name = "Pieces", height_in_cm = 60, length_in_cm = 60, width_in_cm = 60 } }

            };
            var bundleResponse = await productService.CreateProduct(Shops.TestShop_Id, bundleProduct);

            Assert.AreEqual(HttpStatusCode.Created, bundleResponse.StatusCode, bundleResponse.Content.ToString());
        }
    } 
}
