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
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2NDI1MjQ2NjUsImlhdCI6MTYzOTkzMjY2NSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.N5I268aP4X7Qe7c7LRjXD1FHkH5h___L99xQSG09nEM" : token;
        }

        public async Task<IRestResponse<object>> CancelFulfillment(string shopId, string fulfillment_id)
        {
            var client = new RestClientHandler($"{EverstoxShopResources.ShopBaseUrl}/{shopId}/{FulfillmentsUrl}/{fulfillment_id}/{CancelationAction}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<object>(request);
        }
    }
}
