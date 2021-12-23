using Everstox.API.Admin.Imports.Models.Response_Models;
using Everstox.API.Admin.Properties;
using Everstox.Infrastructure;
using RestSharp;

namespace Everstox.API.Admin.Imports
{
    public class ImportsService
    {
        private readonly string _token;
        private const string ImportsUrl = "imports";

        public ImportsService(string token = "")
        {
            _token = string.IsNullOrEmpty(token) ? "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2NDI1MjQ2NjUsImlhdCI6MTYzOTkzMjY2NSwic3ViIjoiNmU1ODkzMDQtMDA0ZC00ODVlLTk0NjQtZWJkNWUwMTY4OTFkIn0.N5I268aP4X7Qe7c7LRjXD1FHkH5h___L99xQSG09nEM" : token;
        }

        public async Task<IRestResponse<Import_Response>> ReturnLastImportId()
        {
            var client = new RestClientHandler($"{EverstoxAdminResources.AdminBaseUrl}/{ImportsUrl}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .AddQuery("limit", "1")
                .AddQuery("stategroup", "error")
                .SetHttpMethod(Method.GET)
                .Build();

            return await client.ExecuteAsync<Import_Response>(request);
        }

        public async Task<IRestResponse<Import_Response>> ImportsActions(string importId, string action = "retry")
        {
            var client = new RestClientHandler($"{EverstoxAdminResources.AdminBaseUrl}/{ImportsUrl}/{importId}/{action}");
            RestRequest request = new RequestBuilder()
                .AddAuthorization(_token)
                .SetContentType()
                .SetHttpMethod(Method.POST)
                .Build();

            return await client.ExecuteAsync<Import_Response>(request);
        }
    }
}
