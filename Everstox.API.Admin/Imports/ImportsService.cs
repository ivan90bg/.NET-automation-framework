using Everstox.API.Admin.Properties;
using Everstox.Infrastructure;
using RestSharp;
using static Everstox.API.Admin.Models.APIAdminModels;

namespace Everstox.API.Admin.Imports
{
    public class ImportsService
    {
        private readonly string _token;
        private const string ImportsUrl = "imports";

        public ImportsService(string token = "")
        {
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Njg3NzI4ODUsImlhdCI6MTY2NjE4MDg4NSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.OMQgO9NqZ1fCuEGn7rji1bvWJNfyA7TRyxwzXOGQMr0" : token;
        }

        public async Task<IRestResponse<Import>> ReturnLastImportId()
        {
            var client = new RestClientHandler($"{EverstoxAdminResources.AdminBaseUrl}/{ImportsUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddQuery("limit", "1")
                .AddQuery("stategroup", "error")
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Import>(request);
        }

        public async Task<IRestResponse<Import>> ImportsActions(string importId, string action = "retry")
        {
            var client = new RestClientHandler($"{EverstoxAdminResources.AdminBaseUrl}/{ImportsUrl}/{importId}/{action}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Import>(request);
        }
    }
}
