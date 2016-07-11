using System;
using System.Collections.Generic;


namespace AuthAndApi.Driver {

    public interface Contract {

        string Name { get; }

        /*
        Uri GetAuthorizationUri(out string stateKey, Uri returnUri = null);

        Uri GetAuthorizationUri(string stateKey, Uri returnUri = null);

        ResourceOwner GetResourceOwner(State state, object data);

        AuthorizationContract Associate(Owner dataSourceOwner, State state, object data);

        void CreateAuthenticatedRequest(Uri uri, AuthorizationContract authorization, string method = "GET");

        void CreateAuthenticatedRequest(string uri, AuthorizationContract authorization, string method = "GET");

        void GetAuthenticatedResponse(Uri uri, AuthorizationContract authorization, string method = "GET");

        void GetAuthenticatedResponse(string uri, AuthorizationContract authorization, string method = "GET");
        */

    }

}
