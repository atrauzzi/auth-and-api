using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using RestSharp;
using AuthorizationRepository = AuthAndApi.Repository.Authorization;


namespace AuthAndApi.Driver {

    public class Oauth2 : Contract {

        protected AuthorizationRepository AuthorizationRepository { get; }

        public string Name { get; }

        public Uri BaseAuthorizationUri { get; }

        public Uri BaseRenewalUri { get; }

        public string ClientId { get; }

        protected string ClientSecret { get; }

        public string ScopeSeparator { get; }

        public ISet<string> Scopes { get; }

        public Oauth2(
            AuthorizationRepository authorizationRepository,
            string name,
            Uri baseAuthorizationUri,
            Uri baseRenewalUri,
            string clientId,
            string clientSecret,
            string scopeSeparator = " ",
            ISet<string> scopes = null
            ) {

            AuthorizationRepository = authorizationRepository;
            Name = name;
            BaseAuthorizationUri = baseAuthorizationUri;
            BaseRenewalUri = baseRenewalUri;
            ClientId = clientId;
            ClientSecret = clientSecret;
            ScopeSeparator = scopeSeparator;

            if(scopes == null)
                Scopes = new HashSet<string>();

        }

        // I have state, generate a key for me.
        public Uri GetAuthorizationUri(IDictionary<string, string> state, out string stateKey) {
            stateKey = CreateStateKey();
            return GetAuthorizationUri(state, stateKey);
        }

        // I have state and a key for it.
        public Uri GetAuthorizationUri(IDictionary<string, string> state, string stateKey) {
            var request = CreateRestRequest();
            request.AddQueryParameter("state", stateKey);
            return BuildUri(request);
        }

        public void Associate(Owner dataSourceOwner, object data) {
            throw new NotImplementedException();
        }

        public void CreateAuthenticatedRequest(string uri, Authorization authorization, string method = "GET") {
            throw new NotImplementedException();
        }

        public void GetAuthenticatedResponse(string uri, Authorization authorization, string method = "GET") {
            throw new NotImplementedException();
        }

        //
        //

        protected Uri BuildUri(RestRequest request) {
            return new RestClient(BaseAuthorizationUri).BuildUri(request);
        }

        // Creates the base request.
        protected RestRequest CreateRestRequest() {

            var request = new RestRequest();

            request.AddQueryParameter("client_id", ClientId);
            request.AddQueryParameter("response_type", "code");
            request.AddQueryParameter("approval_prompt", "auto");
            //request.AddQueryParameter("redirect_uri", "");

            if (Scopes.Count > 0)
                request.AddQueryParameter("scope", string.Join(ScopeSeparator, Scopes));

            return request;

        }

        protected string CreateStateKey(int length = 32) {

            var tokenData = new byte[length];

            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider()) {
                rng.GetBytes(tokenData);
            }

            return Convert.ToBase64String(tokenData);

        }

    }

}
