using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;


namespace AuthAndApi.Oauth2 {

    public abstract class Driver : DriverContract {

        protected Configuration Configuration { get; set; }

        public string Name => Configuration.Name;

        //
        //

        public RestRequest CreateAuthenticatedRequest(Authorization authorization, string method = "GET") {

            Method parsedMethod;
            Enum.TryParse(method, out parsedMethod);

            var request = CreateRequest();

            request.AddQueryParameter("access_token", authorization.Token);
            request.Method = parsedMethod;

            return request;

        }

        //
        //

        protected RestRequest CreateRequest() {
            var request = new RestRequest();
            return request;
        }

        protected async Task<IRestResponse> SendRestRequest(Uri uri, IRestRequest request) {
            using(var client = new RestClient(uri)) {
                return await client.Execute(request);
            }
        }

        protected Uri BuildUri(Uri baseUri, RestRequest request) {
            return new RestClient(baseUri).BuildUri(request);
        }

        protected string CreateStateKey(int length = 32) {

            var tokenData = new byte[length];

            using(RandomNumberGenerator rng = new RNGCryptoServiceProvider()) {
                rng.GetBytes(tokenData);
            }

            return Convert.ToBase64String(tokenData);

        }

    }

}
