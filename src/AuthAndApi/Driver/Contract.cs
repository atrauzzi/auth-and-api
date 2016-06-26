using System;


namespace AuthAndApi.Driver {

    public interface Contract {

        string Name { get; }

        Uri GetAuthorizationUri(out string stateKey, Uri returnUri = null);

        Uri GetAuthorizationUri(string stateKey, Uri returnUri = null);

        void Associate(Owner dataSourceOwner, object data);

        void CreateAuthenticatedRequest(string uri, AuthorizationContract authorization, string method = "GET");

        void GetAuthenticatedResponse(string uri, AuthorizationContract authorization, string method = "GET");

    }

}
