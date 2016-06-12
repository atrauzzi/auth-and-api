using System;
using System.Collections.Generic;


namespace AuthAndApi.Driver {

    public interface Contract {

        string Name { get; }

        Uri GetAuthorizationUri(IDictionary<string, string> state, out string stateKey);

        Uri GetAuthorizationUri(IDictionary<string, string> state, string stateKey);

        void Associate(Owner dataSourceOwner, object data);

        void CreateAuthenticatedRequest(string uri, Authorization authorization, string method = "GET");

        void GetAuthenticatedResponse(string uri, Authorization authorization, string method = "GET");

    }

}
