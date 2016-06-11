namespace AuthAndApi.Driver {

    public interface Contract {

        void Associate(Owner dataSourceOwner, object data);

        void CreateAuthenticatedRequest(string uri, Authorization authorization, string method = "GET");

        void GetAuthenticatedResponse(string uri, Authorization authorization, string method = "GET");

    }

}
