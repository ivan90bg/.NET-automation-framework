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
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Mzk2ODY5NDksImlhdCI6MTYzNzA5NDk0OSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.DGnKspMn7wdz2gfZtnEzWIW1IW4LoMViC-w9BgmjS0w" : token;
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

        public async Task<IRestResponse<Transfer_Response_Model>> GetSingleTransfer(string shopId, string transferId)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferId}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Transfer_Response_Model>(request);
        }


        public async Task<IRestResponse<Transfer_Response_Model>> CreateTransfer(string shopId, Transfer_Request_Model transfer)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<Transfer_Request_Model>(transfer)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Transfer_Response_Model>(request);
        }

        public async Task<IRestResponse<Transfer_Response_Model>> CompleteTransfer(string shopId, string transferId, Complete_Transfer_Model model)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{TransfersUrl}/{transferId}/complete");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .AddRequestBody<Complete_Transfer_Model>(model)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Transfer_Response_Model>(request);
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
