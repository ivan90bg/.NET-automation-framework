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
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2NDYyMTY1NzgsImlhdCI6MTY0MzYyNDU3OCwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.2LZ7t9PFD-YORzama9m3H4l5AHktIfHEbw5QtW4EFC0" : token;
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
