using System;
using System.Threading.Tasks;
using RestSharp.Portable;


namespace AuthAndApi {

    public interface DriverContract {

        string Name { get; }

        RestRequest CreateAuthenticatedRequest(Authorization authorization, string method = "GET");

    }

}
