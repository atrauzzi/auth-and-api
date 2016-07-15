using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;


namespace AuthAndApi.Driver.Oauth2 {

    public abstract class Driver : Contract {

        protected Configuration Configuration { get; set; }

        protected Repository.Authorization AuthorizationRepository { get; set; }

        public string Name => Configuration.Name;

        public abstract void Associate(Authorization authorization, Owner owner);

        //
        //

        public void CreateAuthenticatedRequest(string uri, Authorization authorization, string method = "GET") {
            throw new NotImplementedException();
        }

        public void CreateAuthenticatedRequest(Uri uri, Authorization authorization, string method = "GET") {
            throw new NotImplementedException();
        }


        public void GetAuthenticatedResponse(string uri, Authorization authorization, string method = "GET") {
            throw new NotImplementedException();
        }

        public void GetAuthenticatedResponse(Uri uri, Authorization authorization, string method = "GET") {
            throw new NotImplementedException();
        }

        //
        //

        protected Uri BuildUri(Uri baseUri, RestRequest request) {
            return new RestClient(baseUri).BuildUri(request);
        }

        protected RestRequest CreateRestRequest() {
            var request = new RestRequest();
            return request;
        }

        protected async Task<IRestResponse> SendRestRequest(Uri uri, RestRequest request) {
            using(var client = new RestClient(uri)) {
                return await client.Execute(request);
            }
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
