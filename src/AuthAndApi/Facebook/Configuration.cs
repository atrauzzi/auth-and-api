using System;
using System.Collections.Generic;


namespace AuthAndApi.Facebook {

    public class Configuration : Oauth2.Configuration {

        public Uri BaseResourceOwnerUri { get; set; }

        public Configuration(
            string name,
            string clientId,
            string clientSecret = "",
            string scopes = ""
        ) {

            BaseAuthorizationUri = new Uri("https://www.facebook.com/dialog/oauth");
            BaseAccessTokenUri = new Uri("https://graph.facebook.com/v2.6/oauth/access_token");
            BaseResourceOwnerUri = new Uri("https://graph.facebook.com/v2.6/me?fields=id,name,email");
            BaseApiUri = new Uri("https://graph.facebook.com/v2.6");
            BaseRenewalUri = null;
            ScopeSeparator = " ";

            Name = name;
            ClientId = clientId;
            ClientSecret = clientSecret;

            Scopes = string.IsNullOrEmpty(scopes)
                ? new HashSet<string>()
                : new HashSet<string>(scopes.Split(ScopeSeparator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            ;

        }

    }

}
