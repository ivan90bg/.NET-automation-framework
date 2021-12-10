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


        public async Task<IRestResponse<Transfer_Response_Model>> AcceptTransfer(string warehouseId, string _apiValue, Accept_Transfer_Model transfer)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{TransfersUrl}/accept");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .AddRequestBody<Accept_Transfer_Model>(transfer)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Transfer_Response_Model>(request);
        }

        public async Task<IRestResponse<Transfer_Shipment_Response_Model>> ReceiveTransferShipment(string warehouseId, string _apiValue, Receive_TransferShipment_Model receive_TransferShipment)
        {
            var client = new RestClientHandler($"{EverstoxWarehousesResources.WarehouseBaseUrl}/{warehouseId}/{TransfersUrl}/received_shipment");
            RestRequest request = new RequestBuilder()
                .AddApiKeyAuthorization(_apiKey, _apiValue)
                .AddRequestBody<Receive_TransferShipment_Model>(receive_TransferShipment)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Transfer_Shipment_Response_Model>(request);
        }
    }
}
