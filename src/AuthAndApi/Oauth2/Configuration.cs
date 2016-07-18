using System;
using System.Collections.Generic;


namespace AuthAndApi.Oauth2 {

    public class Configuration : AuthAndApi.Configuration {

        public virtual Uri BaseAuthorizationUri { get; set; }

        public virtual Uri BaseAccessTokenUri { get; set; }

        public virtual Uri BaseApiUri { get; set; }

        public virtual Uri BaseRenewalUri { get; set; }

        public virtual string ClientId { get; set; }

        public virtual string ClientSecret { get; set; }

        public virtual string ScopeSeparator { get; set; }

        public virtual ISet<string> Scopes { get; set; }

        protected Configuration() {
            // Empty paramaterless constructor for subclasses.
        }

        public Configuration(
            string name,
            string clientId,
            string baseAuthorizationUri,
            string baseAccessTokenUri,
            string baseApiUri = "",
            string baseRenewalUri = "",
            string clientSecret = "",
            string scopeSeparator = " ",
            string scopes = ""
        ) {

            Name = name;

            BaseAuthorizationUri = new Uri(baseAuthorizationUri);
            BaseAccessTokenUri = new Uri(baseAccessTokenUri);

            BaseApiUri = string.IsNullOrEmpty(baseApiUri) ? null : new Uri(baseApiUri);
            BaseRenewalUri = string.IsNullOrEmpty(baseRenewalUri) ? null : new Uri(baseRenewalUri);

            ClientId = clientId;
            ClientSecret = clientSecret;
            ScopeSeparator = scopeSeparator;
            
            Scopes = string.IsNullOrEmpty(scopes) ? 
                new HashSet<string>() 
                : new HashSet<string>(scopes.Split(scopeSeparator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            ;

        }

    }

}
