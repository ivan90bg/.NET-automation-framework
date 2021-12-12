using Everstox.API.Warehouses.Properties;
using Everstox.API.Warehouses.Stocks.Models.Request_Models;
using Everstox.API.Warehouses.Stocks.Models.Response_Models;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Warehouses.Stocks
{
    public class StocksService
    {
        private readonly string _apiKey = "everstox-warehouse-api-token";
        private const string StocksUrl = "stocks";


        public async Task<IRestResponse<Stock_Response>> CreateNewStock(string warehouseId, string _apiValue, Stock_Request stock)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{StocksUrl}");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .AddRequestBody<Stock_Request>(stock)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Stock_Response>(request);
        }

    }
}
