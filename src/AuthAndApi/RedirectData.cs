using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AuthAndApi {

    public class RedirectData {

        public Uri RedirectUri { get; }

        public IDictionary<string, string> State { get; }

        public RedirectData(Uri redirectUri, IDictionary<string, string> state) {
            RedirectUri = redirectUri;
            State = state;
        }

    }

}
