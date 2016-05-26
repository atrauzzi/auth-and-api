using System.Collections.Generic;
using AuthorizationEntity = AuthAndApi.Authorization;

namespace AuthAndApi.Repository {

    public interface Authorization<Identifier> {

        AuthorizationEntity Get(Identifier id);

        IEnumerable<AuthorizationEntity> GetForOwner(Owner owner);

        IEnumerable<AuthorizationEntity> UpdateOrCreate();

    }

}
