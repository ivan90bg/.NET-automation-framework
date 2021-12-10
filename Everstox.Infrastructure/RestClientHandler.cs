using RestSharp;
namespace Everstox.Infrastructure
{
   public class RestClientHandler
   {
      private readonly string _url;

      public RestClientHandler(string url)
      {
         _url = url;
      }

      public async Task<IRestResponse<TResponse>> ExecuteAsync<TResponse>(RestRequest request)
      {
         var restClient = new RestClient(_url);
         return await restClient.ExecuteAsync<TResponse>(request);
      }
   }
}
