using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Orders;
using Everstox.Infrastructure;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using static Everstox.API.Shop.Models.APIShopModels;
using static Everstox.Infrastructure.Infrastructure_Data.EverstoxAPIData;

namespace xUnitIntegration
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1Async()
        {
            var orderRequest = GenerateOrderRequestFromJson("OrderWithValidBatchProduct.json");
            var orderResponse = await CreateOrder(orderRequest);

            ValidateOrder(orderRequest, orderResponse);

        }

        private Order_create GenerateOrderRequestFromJson(string fileName)
        {
            var orderRequest = RequestDeserializer.Deserialize<Order_create>(fileName);
            orderRequest.Order_number = $"Order_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8)}";
            return orderRequest;
        }

        private async Task<IRestResponse<Order_details>> CreateOrder(Order_create orderRequest)
        {
            var orderService = new OrderService();
            return await CreateOrder(Shops.TestShop_Id, orderRequest);

        }
        public async Task<IRestResponse<Order_details>> CreateOrder(string shopId, Order_create order)
        {
            var client = new RestClientHandler($"https://api.qa1.everstox.com/api/v1/shops/{shopId}/orders");
            RestRequest request = new RequestBuilder()
                .AddAuthorization("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Njg3NzI4ODUsImlhdCI6MTY2NjE4MDg4NSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.OMQgO9NqZ1fCuEGn7rji1bvWJNfyA7TRyxwzXOGQMr0")
                .SetContentType()
                .AddRequestBody<Order_create>(order)
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Order_details>(request);
        }
        private void ValidateOrder(Order_create orderRequest, IRestResponse<Order_details> orderResponse)
        {
            Assert.Equal(HttpStatusCode.Created, orderResponse.StatusCode);
            Assert.Equal(orderRequest.Order_priority, orderResponse.Data.Order_priority);
            Assert.Equal(EnumString.GetStringValue(Fulfillment_State.In_Fullfilment), orderResponse.Data.State);
            Assert.Equal(EnumString.GetStringValue(Warehouse_Names.Bolec_Warehouse), orderResponse.Data.Fulfillments[0].Warehouse.Name);
            Assert.Equal("automationbatch", orderResponse.Data.Order_items[0].Custom_attributes[0].Attribute_value);
            Assert.Equal(EnumString.GetStringValue(Fulfillment_State.Warehouse_confirmation_pending), orderResponse.Data.Fulfillments[0].State);
        }
    }
}