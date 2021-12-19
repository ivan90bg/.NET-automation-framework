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

        public TransfersService(string token = "")
        {
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2NDI1MjQ2NjUsImlhdCI6MTYzOTkzMjY2NSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.N5I268aP4X7Qe7c7LRjXD1FHkH5h___L99xQSG09nEM" : token;
        }

        public async Task<IRestResponse<List<object>>> GetTransfers(string shopId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<List<object>>(request);
        }

        public async Task<IRestResponse<Transfer_Response>> GetSingleTransfer(string shopId, string transferId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
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

        public async Task<IRestResponse<Transfer_Response>> CompleteTransfer(string shopId, string transferId, TransferComplete_Request model)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferId}/complete");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<TransferComplete_Request>(model)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Transfer_Response>(request);
        }

        public async Task<IRestResponse<object>> DeleteTransfer(string shopId, string transferId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.DELETE)
                .Build();

            return await client.ExecuteAsync<object>(request);
        }
    }
}
