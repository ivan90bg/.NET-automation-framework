using Everstox.API.Warehouses.Fulfillments.Models.Request_Model;
using Everstox.API.Warehouses.Fulfillments.Models.Response_Model;
using Everstox.API.Warehouses.Properties;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Warehouses.Fulfillments
{
    public class FulfillmentsService
    {
        private readonly string _apiKey = "everstox-warehouse-api-token";
        private const string FulfillmentsUrl = "fulfillments";


        public async Task<IRestResponse<List<Fulfillment_Response_Model>>> GetFulfillments(string warehouseId, string _apiValue)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{FulfillmentsUrl}");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<List<Fulfillment_Response_Model>>(request);
        }


        public async Task<IRestResponse<Fulfillment_Response_Model>> FulfillmentsAction(string warehouseId, string action, string _apiValue, List<Fulfillment_Request_Model> fulfillment)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{FulfillmentsUrl}/{action}");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .AddRequestBody<List<Fulfillment_Request_Model>>(fulfillment)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Fulfillment_Response_Model>(request);
        }
    }
}
