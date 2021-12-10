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
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Mzk2ODY5NDksImlhdCI6MTYzNzA5NDk0OSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.DGnKspMn7wdz2gfZtnEzWIW1IW4LoMViC-w9BgmjS0w" : token;
        }

        public async Task<IRestResponse<List<Product_Response>>> GetProducts(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<List<Product_Response>>(request);
        }

        public async Task<IRestResponse<Product_Response>> GetSingleProduct(string shopId, string productId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}/{productId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Product_Response>(request);
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

        public async Task<IRestResponse<object>> DeleteProduct(string shopId, string productId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{ProductsUrl}/{productId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.DELETE)
                .Build();

            return await client.ExecuteAsync<object>(request);
        }

    }
}
