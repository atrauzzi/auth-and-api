using System;
using static AuthAndApi.Driver.Oauth2.Driver;
using BaseState = AuthAndApi.Driver.State;


namespace AuthAndApi.Driver.Oauth2 {

    public class State : BaseState {

        public Uri ReturnUri { get; }

        public Uri AuthorizationUri { get; }

        public State(string driver, Uri authorizationUri, string key, Uri returnUri = null) {
            Driver = driver;
            AuthorizationUri = authorizationUri;
            Key = key;
            ReturnUri = returnUri;
        }

    }

}
