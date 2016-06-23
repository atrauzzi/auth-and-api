using System;
using System.Collections.Generic;


// This DTO represents information useful to an implementing project's HTTP controller layer.
namespace AuthAndApi {

    public class State {

        public string Driver { get; }

        public Uri AuthorizationUri { get; }

        public string Key { get; }

        public State(string driver, Uri authorizationUri, string key = null) {
            Driver = driver;
            AuthorizationUri = authorizationUri;
            Key = key;
        }

    }

}
