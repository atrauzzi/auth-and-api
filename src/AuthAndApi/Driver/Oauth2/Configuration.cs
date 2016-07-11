using System;
using System.Collections.Generic;
using BaseConfiguration = AuthAndApi.Driver.Configuration;


namespace AuthAndApi.Driver.Oauth2 {

    public class Configuration : BaseConfiguration {

        public Uri BaseAuthorizationUri { get; set; }

        public Uri BaseAccessTokenUri { get; set; }

        public Uri BaseResourceOwnerUri { get; set; }

        public Uri BaseApiUri { get; set; }

        public Uri BaseRenewalUri { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ScopeSeparator { get; set; }

        public ISet<string> Scopes { get; set; }

        public Configuration(
            string name,
            string clientId,
            string baseAuthorizationUri,
            string baseAccessTokenUri,
            string baseResourceOwnerUri,
            string baseApiUri = "",
            string baseRenewalUri = "",
            string clientSecret = "",
            string scopeSeparator = " ",
            string scopes = ""
        ) {

            Name = name;

            BaseAuthorizationUri = new Uri(baseAuthorizationUri);
            BaseAccessTokenUri = new Uri(baseAccessTokenUri);
            BaseResourceOwnerUri = new Uri(baseResourceOwnerUri);

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
