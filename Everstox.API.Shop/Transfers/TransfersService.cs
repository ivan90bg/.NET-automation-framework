using Everstox.API.Shop.Properties;
using Everstox.API.Shop.Transfers.Models.Request_Models;
using Everstox.API.Shop.Transfers.Models.Response_Models;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Shop.Transfers
{
    public class TransfersService
    {
        private readonly string _token;
        private const string TransfersUrl = "transfers";
        private const string ActionCompleted = "complete";

        public TransfersService(string token = "")
        {
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2NTIyNzYzMTgsImlhdCI6MTY0OTY4NDMxOCwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.IEOqtBbH8rcvCFB7Bx6-fYRn7TX3otOAVizoMy4ZtxQ" : token;
        }

        public async Task<IRestResponse<TransferList_Response>> GetAllTransfers(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<TransferList_Response>(request);
        }

        public async Task<IRestResponse<Transfer_Response>> GetTransferById(string shopId, string transferId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Transfer_Response>(request);
        }

        public async Task<IRestResponse<Transfer_Response>> GetTransferByNumber(string shopId, string transferNumber)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferNumber}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddQuery("transfer_number", transferNumber)
                .AddQuery("stategroup", "all")
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Transfer_Response>(request);
        }

        public async Task<IRestResponse<Transfer_Response>> CreateTransfer(string shopId, Transfer_Request transfer)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<Transfer_Request>(transfer)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Transfer_Response>(request);
        }

        public async Task<IRestResponse<Transfer_Response>> CompleteTransfer(string shopId, string transferId, TransferComplete_Request completedTransfer)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferId}/{ActionCompleted}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<TransferComplete_Request>(completedTransfer)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Transfer_Response>(request);
        }

        public async Task<IRestResponse> DeleteTransfer(string shopId, string transferId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.DELETE)
                .Build();

            return await client.ExecuteAsync(request);
        }
    }
}
