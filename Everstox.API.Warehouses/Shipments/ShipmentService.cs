using Everstox.API.Warehouses.Properties;
using Everstox.API.Warehouses.Shipments.Models.Request_Models;
using Everstox.API.Warehouses.Shipments.Models.Response_Models;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Warehouses.Shipments
{
    public class ShipmentService
    {
        private readonly string _apiKey = "everstox-warehouse-api-token";
        private const string ShipmentsUrl = "shipments";


        public async Task<IRestResponse<Shipment_Response>> CreateShipment(string warehouseId, string _apiValue, Shipment_Request shipment)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{ShipmentsUrl}");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .AddRequestBody<Shipment_Request>(shipment)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Shipment_Response>(request);
        }

        public async Task<IRestResponse<Shipment_Update_Response>> UpdateShipment(string warehouseId, string _apiValue, string shipment_id, Shipment_Update_Request shipmentUpdate)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{ShipmentsUrl}/{shipment_id}");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .AddRequestBody<Shipment_Update_Request>(shipmentUpdate)
                .SetContentType()
                .SetHttpMethod(Method.PUT)
                .Build();

            return await client.ExecuteAsync<Shipment_Update_Response>(request);
        }
    }
}
