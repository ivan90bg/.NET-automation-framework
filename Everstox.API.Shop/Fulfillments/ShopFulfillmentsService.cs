using Everstox.API.Shop.Properties;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Shop.Fulfillments
{
    public class ShopFulfillmentsService
    {
        private readonly string _token;
        private const string FulfillmentsUrl = "fulfillment";
        private const string CancelationAction = "cancel";

        public ShopFulfillmentsService(string token = "")
        {
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Njg3NzI4ODUsImlhdCI6MTY2NjE4MDg4NSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.OMQgO9NqZ1fCuEGn7rji1bvWJNfyA7TRyxwzXOGQMr0" : token;
        }

        public async Task<IRestResponse> CancelFulfillment(string shopId, string fulfillment_id)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{FulfillmentsUrl}/{fulfillment_id}/{CancelationAction}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync(request);
        }
    }
}
