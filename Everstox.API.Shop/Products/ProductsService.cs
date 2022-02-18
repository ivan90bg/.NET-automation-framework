using Everstox.API.Shop.Products.Models.Request_Models;
using Everstox.API.Shop.Products.Models.Response_Models;
using Everstox.API.Shop.Properties;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Shop.Products
{
    public class ProductsService
    {
        private readonly string _token;
        private const string ProductsUrl = "products";

        public ProductsService(string token = "")
        {
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2NDYyMTY1NzgsImlhdCI6MTY0MzYyNDU3OCwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.2LZ7t9PFD-YORzama9m3H4l5AHktIfHEbw5QtW4EFC0" : token;
        }

        public async Task<IRestResponse<ProductList_Response>> GetAllProducts(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<ProductList_Response>(request);
        }

        public async Task<IRestResponse<ProductList_Response>> GetProductById(string shopId, string productId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}/{productId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<ProductList_Response>(request);
        }

        public async Task<IRestResponse<ProductList_Response>> GetProductByName(string shopId, string productName)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddQuery("name", productName)
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<ProductList_Response>(request);
        }

        public async Task<IRestResponse<Product_Response>> CreateProduct(string shopId, Product_Request product)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<Product_Request>(product)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Product_Response>(request);
        }

        public async Task<IRestResponse<Product_Response>> UpdateProduct(string shopId, string productId, Product_Request product)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}/{productId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<Product_Request>(product)
                .SetContentType()
                .SetHttpMethod(Method.PUT)
                .Build();

            return await client.ExecuteAsync<Product_Response>(request);
        }

        public async Task<IRestResponse> DeleteProduct(string shopId, string productId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}/{productId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.DELETE)
                .Build();

            return await client.ExecuteAsync(request);
        }

    }
}
