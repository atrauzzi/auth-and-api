using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;


namespace AuthAndApi.Driver.Oauth2 {

    public class AuthorizationCode : Driver {

        public AuthorizationCode(
            Configuration configuration, 
            Repository.Authorization authorizationRepository
        ) {
            Configuration = configuration;
            AuthorizationRepository = authorizationRepository;
        }

        //
        //

        public State Start(Uri returnUri) {

            string stateKey;
            var authorizationUri = GetAuthorizationUri(out stateKey, returnUri);

            var state = new Oauth2.State(
                this.Configuration.GrantTypes, 
                this.Name, 
                authorizationUri, 
                stateKey, 
                returnUri
            );

            return state;

        }

        public async Task<Authorization> Complete(Owner owner, State state, string code) {

            var authorization = new Authorization {
                Owner = owner
            };

            var request = CreateRestRequest();
            request.AddQueryParameter("client_id", Configuration.ClientId);
            request.AddQueryParameter("client_secret", Configuration.ClientSecret);
            request.AddQueryParameter("redirect_uri", state.ReturnUri);
            request.AddQueryParameter("code", code);

            var response = await SendRestRequest(Configuration.BaseAccessTokenUri, request);

            AuthorizationRepository.UpdateOrCreate(authorization);

            return authorization;

        }

        //
        //

        public Uri GetAuthorizationUri(out string stateKey, Uri returnUri = null) {
            stateKey = CreateStateKey();
            return GetAuthorizationUri(stateKey, returnUri);
        }

        public Uri GetAuthorizationUri(string stateKey, Uri returnUri = null) {

            var request = CreateRestRequest();

            request.AddQueryParameter("state", stateKey);
            request.AddQueryParameter("redirect_uri", returnUri?.ToString());
            request.AddQueryParameter("client_id", Configuration.ClientId);
            request.AddQueryParameter("response_type", "code");
            request.AddQueryParameter("approval_prompt", "auto");

            if (Configuration.Scopes.Count > 0)
                request.AddQueryParameter("scope", string.Join(Configuration.ScopeSeparator, Configuration.Scopes));

            return BuildUri(Configuration.BaseAuthorizationUri, request);

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
