using System;
using System.Collections.Generic;


// This DTO represents information useful to an implementing project's HTTP controller layer.
namespace AuthAndApi {

    public class RedirectData {

        public Uri Uri { get; }

        public IDictionary<string, string> State { get; }

        public string StateKey { get; }

        public RedirectData(Uri uri, IDictionary<string, string> state, string stateKey = null) {
            Uri = uri;
            State = state;
            StateKey = stateKey;
        }

    }

}
