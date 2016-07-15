using System;
using System.Threading.Tasks;
using RestSharp.Portable;


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

        public AuthorizationCodeState Start(Uri returnUri) {

            string stateKey;
            var authorizationUri = GetAuthorizationUri(out stateKey, returnUri);

            var state = new AuthorizationCodeState(
                this.Name, 
                authorizationUri, 
                stateKey, 
                returnUri
            );

            return state;

        }

        public async Task<Authorization> Complete(AuthorizationCodeState state, string code) {

            var authorization = new Authorization();

            var request = CreateRestRequest();
            request.AddQueryParameter("client_id", Configuration.ClientId);
            request.AddQueryParameter("client_secret", Configuration.ClientSecret);
            request.AddQueryParameter("redirect_uri", state.ReturnUri);
            request.AddQueryParameter("code", code);

            var response = await SendRestRequest(Configuration.BaseAccessTokenUri, request);

            // ToDo: Actually digest the response here.

            AuthorizationRepository.UpdateOrCreate(authorization);

            return authorization;

        }

        public override void Associate(Authorization authorization, Owner owner) {
            // ToDo: Do repository things in here.
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

    }

}
