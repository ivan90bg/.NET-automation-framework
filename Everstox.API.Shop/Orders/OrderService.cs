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
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2NDI1MjQ2NjUsImlhdCI6MTYzOTkzMjY2NSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.N5I268aP4X7Qe7c7LRjXD1FHkH5h___L99xQSG09nEM" : token;
        }

        public async Task<IRestResponse<OrderList_Response>> GetAllOrders(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddQuery("stategroup", "all")
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

        public async Task<IRestResponse<Order_Response>> GetOrderById(string shopId, string orderId)
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

        public async Task<IRestResponse> CancelOrder(string shopId, string orderId, OrderCancel_Request orderCancellation)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{OrderUrl}/{orderId}/{Cancellation}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddRequestBody<OrderCancel_Request>(orderCancellation)
                .SetHttpMethod(Method.PUT)
                .Build();

            return await client.ExecuteAsync(request);
        }


    }
}
