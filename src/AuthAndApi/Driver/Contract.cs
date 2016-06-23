using System;
using System.Collections.Generic;


namespace AuthAndApi.Driver {

    public interface Contract {

        string Name { get; }

        Uri GetAuthorizationUri(out string stateKey, Uri returnUri = null);

        Uri GetAuthorizationUri(string stateKey, Uri returnUri = null);

        void Associate(Owner dataSourceOwner, object data);

        void CreateAuthenticatedRequest(string uri, Authorization authorization, string method = "GET");

        void GetAuthenticatedResponse(string uri, Authorization authorization, string method = "GET");

    }

}
