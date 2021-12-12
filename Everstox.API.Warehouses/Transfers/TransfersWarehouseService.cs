using Everstox.API.Shop.Transfers.Models.Response_Models;
using Everstox.API.Warehouses.Properties;
using Everstox.API.Warehouses.Transfers.Models.Request_Models;
using Everstox.API.Warehouses.Transfers.Models.Response_Models;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Warehouses.Transfers
{
    public class TransfersWarehouseService
    {
        private readonly string _apiKey = "everstox-warehouse-api-token";
        private const string TransfersUrl = "transfers";


        public async Task<IRestResponse<Transfer_Response>> AcceptTransfer(string warehouseId, string _apiValue, TransferAccept_Request transfer)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{TransfersUrl}/accept");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .AddRequestBody<TransferAccept_Request>(transfer)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Transfer_Response>(request);
        }

        public async Task<IRestResponse<TransferShipment_Response>> ReceiveTransferShipment(string warehouseId, string _apiValue, TransferShipment_Request receive_TransferShipment)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{TransfersUrl}/received_shipment");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .AddRequestBody<TransferShipment_Request>(receive_TransferShipment)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<TransferShipment_Response>(request);
        }
    }
}
