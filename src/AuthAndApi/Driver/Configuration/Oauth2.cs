using System;
using System.Collections.Generic;
using System.Linq;


namespace AuthAndApi.Driver.Configuration {

    public class Oauth2 {

        public string Name { get; set; }

        public Uri BaseAuthorizationUri { get; set; }

        public Uri BaseRenewalUri { get; set; }

        public string ClientId { get; set; }

        protected string ClientSecret { get; set; }

        public string ScopeSeparator { get; set; }

        public ISet<string> Scopes { get; set; }

        public Oauth2(
            string name,
            string baseAuthorizationUri,
            string baseRenewalUri = "",
            string clientId = "",
            string clientSecret = "",
            string scopeSeparator = " ",
            string scopes = ""
        )
        : this(
            name,
            new Uri(baseAuthorizationUri),
            baseRenewalUri.Any() ? new Uri(baseRenewalUri) : null,
            clientId,
            clientSecret,
            scopeSeparator,
            scopes.Split(scopeSeparator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        ) {
        }

        public Oauth2(
            string name,
            Uri baseAuthorizationUri,
            Uri baseRenewalUri,
            string clientId,
            string clientSecret,
            string scopeSeparator,
            IList<string> scopes = null
        ) {

            Name = name;
            BaseAuthorizationUri = baseAuthorizationUri;
            BaseRenewalUri = baseRenewalUri;
            ClientId = clientId;
            ClientSecret = clientSecret;
            ScopeSeparator = scopeSeparator;

            if(scopes == null)
                Scopes = new HashSet<string>();
            else
                Scopes = new HashSet<string>(scopes.Distinct());

        }

    }

}
