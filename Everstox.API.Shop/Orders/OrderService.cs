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
        private const string Cancellation = "cancel";

        public OrderService(string token = "")
        {
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Mzk2ODY5NDksImlhdCI6MTYzNzA5NDk0OSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.DGnKspMn7wdz2gfZtnEzWIW1IW4LoMViC-w9BgmjS0w" : token;
        }

        public async Task<IRestResponse<OrderList_Response>> GetOrders(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<OrderList_Response>(request);
        }

        public async Task<IRestResponse<OrderList_Response>> GetLastCreatedOrder(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddQuery("limit", "1")
                .AddQuery("stategroup", "all")
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<OrderList_Response>(request);
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

        public async Task<IRestResponse<OrderList_Response>> GetOrderByNumber(string shopId, string orderNumber)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddQuery("order_number", orderNumber)
                .AddQuery("stategroup", "all")
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<OrderList_Response>(request);
        }

        public async Task<IRestResponse<Order_Response>> CreateOrder(string shopId, Order_Request order)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)               
                .SetContentType()
                .AddRequestBody<Order_Request>(order)
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Order_Response>(request);
        }

        public async Task<IRestResponse<object>> CancelOrder(string shopId, string orderId, OrderCancel_Request orderCancellation)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}/{orderId}/{Cancellation}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddRequestBody<OrderCancel_Request>(orderCancellation)
                .SetHttpMethod(Method.PUT)
                .Build();

            return await client.ExecuteAsync<object>(request);
        }


    }
}
