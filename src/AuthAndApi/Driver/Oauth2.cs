using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Oauth2Configuration = AuthAndApi.Driver.Configuration.Oauth2;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using AuthorizationRepository = AuthAndApi.Repository.Authorization;


namespace AuthAndApi.Driver {

    public class Oauth2 : Contract {

        protected Oauth2Configuration Configuration { get; }

        protected AuthorizationRepository AuthorizationRepository { get; }

        public string Name => Configuration.Name;

        public Oauth2(Oauth2Configuration configuration, AuthorizationRepository authorizationRepository) {
            Configuration = configuration;
            AuthorizationRepository = authorizationRepository;
        }

        // Generate a key for me.
        public Uri GetAuthorizationUri(out string stateKey, Uri returnUri = null) {
            stateKey = CreateStateKey();
            return GetAuthorizationUri(stateKey, returnUri);
        }

        // I already have a state key.
        public Uri GetAuthorizationUri(string stateKey, Uri returnUri = null) {
            var request = CreateRestRequest();
            request.AddQueryParameter("state", stateKey);
            request.AddQueryParameter("redirect_uri", returnUri?.ToString());
            return BuildUri(request);
        }

        //
        //

        public void Associate(Owner dataSourceOwner, object data) {
            throw new NotImplementedException();
        }

        //
        //

        public void CreateAuthenticatedRequest(string uri, Authorization authorization, string method = "GET") {
            throw new NotImplementedException();
        }

        public void GetAuthenticatedResponse(string uri, Authorization authorization, string method = "GET") {
            throw new NotImplementedException();
        }

        //
        //

        protected Uri BuildUri(RestRequest request) {
            return new RestClient(Configuration.BaseAuthorizationUri).BuildUri(request);
        }

        // Creates the base request.
        protected RestRequest CreateRestRequest() {

            var request = new RestRequest();

            request.AddQueryParameter("client_id", Configuration.ClientId);
            request.AddQueryParameter("response_type", "code");
            request.AddQueryParameter("approval_prompt", "auto");

            if(Configuration.Scopes.Count > 0)
                request.AddQueryParameter("scope", string.Join(Configuration.ScopeSeparator, Configuration.Scopes));

            return request;

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
