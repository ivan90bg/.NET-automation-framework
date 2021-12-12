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

        public async Task<IRestResponse<List<Order_Response>>> GetOrders(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<List<Order_Response>>(request);
        }

        public async Task<IRestResponse<Order_Response>> GetSingleOrder(string shopId, string orderId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}/{orderId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Order_Response>(request);
        }

        public async Task<IRestResponse<Order_Response>> GetOrderByNumber(string shopId, string orderNumber)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddQuery("order_number", orderNumber)
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Order_Response>(request);
        }

        public async Task<IRestResponse<Order_Response>> CreateOrder(string shopId, Order_Request order)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<Order_Request>(order)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Order_Response>(request);
        }

 
    }
}
