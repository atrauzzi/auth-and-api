using Newtonsoft.Json;


namespace AuthAndApi.Oauth2 {

    public struct AuthorizationCodeResponse {

        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public string ExpiresIn { get; set; }

        [JsonConstructor]
        public AuthorizationCodeResponse(string access_token, string token_type, string expires_in) {
            AccessToken = access_token;
            TokenType = token_type;
            ExpiresIn = expires_in;
        }

    }

}
