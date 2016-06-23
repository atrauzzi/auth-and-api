using System.Collections.Generic;
using AuthorizationEntity = AuthAndApi.Authorization;


namespace AuthAndApi.Repository {

    public interface Authorization {

        IEnumerable<AuthorizationEntity> GetForOwner(Owner owner);

        void UpdateOrCreate(AuthorizationEntity authorization);

    }

}
