using Everstox.API.Shop.Orders.Models.Request_Models;
using Everstox.API.Shop.Orders.Models.Response_Models;
using Everstox.API.Shop.Properties;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Shop.Orders
{
    public class OrderService
    {
        private readonly string _token;
        private const string OrderUrl = "orders";

        public OrderService(string token = "")
        {
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Mzk2ODY5NDksImlhdCI6MTYzNzA5NDk0OSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.DGnKspMn7wdz2gfZtnEzWIW1IW4LoMViC-w9BgmjS0w" : token;
        }

        public async Task<IRestResponse<List<Order_Response_Model>>> GetOrders(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<List<Order_Response_Model>>(request);
        }

        public async Task<IRestResponse<Order_Response_Model>> GetSingleOrder(string shopId, string orderId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}/{orderId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Order_Response_Model>(request);
        }


        public async Task<IRestResponse<Order_Response_Model>> CreateOrder(string shopId, Order_Creation_Model order)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<Order_Creation_Model>(order)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Order_Response_Model>(request);
        }

        public async Task<IRestResponse<object>> DeleteOrder(string shopId, string orderId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}/{orderId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.DELETE)
                .Build();

            return await client.ExecuteAsync<object>(request);
        }

    }
}
