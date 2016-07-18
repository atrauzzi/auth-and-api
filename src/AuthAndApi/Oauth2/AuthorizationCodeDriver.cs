using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NodaTime;
using RestSharp.Portable;


namespace AuthAndApi.Oauth2 {

    public class AuthorizationCodeDriver : Driver {

        public AuthorizationCodeDriver(Configuration configuration) {
            Configuration = configuration;
        }

        //
        //

        public AuthorizationCodeState Start(Uri returnUri) {

            string stateKey;
            var authorizationUri = GetAuthorizationUri(out stateKey, returnUri);

            var state = new AuthorizationCodeState(
                Name, 
                authorizationUri, 
                stateKey, 
                returnUri
            );

            return state;

        }

        public virtual async Task<Authorization> Complete(AuthorizationCodeState state, string code) {

            var request = CreateRequest();
            request.AddQueryParameter("client_id", Configuration.ClientId);
            request.AddQueryParameter("client_secret", Configuration.ClientSecret);
            request.AddQueryParameter("redirect_uri", state.ReturnUri);
            request.AddQueryParameter("code", code);

            var response = await SendRestRequest(Configuration.BaseAccessTokenUri, request);
            var authorizationCodeResponse = JsonConvert.DeserializeObject<AuthorizationCodeResponse>(response.Content);

            var authorization = new Authorization {
                CreatedAt = SystemClock.Instance.GetCurrentInstant().InUtc(),
                DriverName = Name,
                Token = authorizationCodeResponse.AccessToken,
            };

            if(authorizationCodeResponse.ExpiresIn != null) {
                var expiresIn = Duration.FromSeconds(long.Parse(authorizationCodeResponse.ExpiresIn));
                var expiresAt = SystemClock.Instance.GetCurrentInstant().Plus(expiresIn).InUtc();
                authorization.ExpiresAt = expiresAt;
            }

            return authorization;

        }

        //
        //

        public Uri GetAuthorizationUri(out string stateKey, Uri returnUri = null) {
            stateKey = CreateStateKey();
            return GetAuthorizationUri(stateKey, returnUri);
        }

        public Uri GetAuthorizationUri(string stateKey, Uri returnUri = null) {

            var request = CreateRequest();

            request.AddQueryParameter("state", stateKey);
            request.AddQueryParameter("redirect_uri", returnUri?.ToString());
            request.AddQueryParameter("client_id", Configuration.ClientId);
            request.AddQueryParameter("response_type", "code");
            request.AddQueryParameter("approval_prompt", "auto");

            if (Configuration.Scopes.Count > 0)
                request.AddQueryParameter("scope", string.Join(Configuration.ScopeSeparator, Configuration.Scopes));

            return BuildUri(Configuration.BaseAuthorizationUri, request);

        }

    }

}
