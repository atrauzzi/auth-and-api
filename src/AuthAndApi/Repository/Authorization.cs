using System.Collections.Generic;


namespace AuthAndApi.Repository {

    public interface Authorization {

        IEnumerable<AuthAndApi.AuthorizationContract> GetForOwner(AuthAndApi.Owner owner);

        void UpdateOrCreate(AuthAndApi.AuthorizationContract authorization);

    }

}
