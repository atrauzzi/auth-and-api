using System;


namespace AuthAndApi.Oauth2 {

    public class AuthorizationCodeState : State {

        public Uri ReturnUri { get; }

        public Uri AuthorizationUri { get; }

        public AuthorizationCodeState(string driver, Uri authorizationUri, string key, Uri returnUri = null) {
            Driver = driver;
            AuthorizationUri = authorizationUri;
            Key = key;
            ReturnUri = returnUri;
        }

    }

}
