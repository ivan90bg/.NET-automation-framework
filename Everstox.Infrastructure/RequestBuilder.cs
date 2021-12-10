using Newtonsoft.Json;
using RestSharp;

namespace Everstox.Infrastructure
{
    public class RequestBuilder
    {
        private readonly RestRequest _request;

        public RequestBuilder()
        {
            _request = new RestRequest();
        }

        public RequestBuilder AddAuthorization(string token)
        {
            _request.AddHeader("Authorization", $"Bearer {token}");
            return this;
        }

        public RequestBuilder AddApiKeyAuthorization(string key, string value)
        {
            _request.AddHeader(key, value);
            return this;
        }

        public RequestBuilder AddRequestBody(string jsonPayload)
        {
            _request.AddParameter("application/json", jsonPayload, ParameterType.RequestBody);
            return this;
        }

        public RequestBuilder AddQuery(string parameterName, string parameterValue)
        {
            _request.AddQueryParameter(parameterName, parameterValue);
            return this;
        }

        public RequestBuilder AddRequestBody<TRequest>(TRequest requestObject) where TRequest : class
        {
            string json = JsonConvert.SerializeObject(requestObject);
            AddRequestBody(json);
            return this;
        }

        public RequestBuilder SetContentType(string contentType = "application/json")
        {
            _request.AddHeader("Accept", contentType);
            _request.RequestFormat = DataFormat.Json;
            return this;
        }

        public RequestBuilder SetHttpMethod(Method method)
        {
            _request.Method = method;
            return this;
        }

        public RestRequest Build() => _request;
    }
}