using System;
using System.Threading.Tasks;
using AuthAndApi.Oauth2;
using Newtonsoft.Json;
using RestSharp.Portable;


namespace AuthAndApi.Facebook {

    public class Driver : AuthorizationCodeDriver, AbleToAuthenticate {

        protected new Configuration Configuration;

        public Driver(Configuration configuration)
        : base(configuration) {
        }

        public async Task<ValueType> GetOwnerMeta(Authorization authorization) {

            var request = CreateAuthenticatedRequest(authorization);
            request.AddQueryParameter("fields", "id,first_name,last_name,email");
            var response = await SendRestRequest(Configuration.BaseResourceOwnerUri, request);
            var ownerMeta = JsonConvert.DeserializeObject<OwnerMeta>(response.Content);

            return ownerMeta;

        }

    }

}
