using System.Collections.Generic;


namespace AuthAndApi.Repository {

    public interface Authorization {

        IEnumerable<AuthAndApi.Authorization> GetForOwner(AuthAndApi.Owner owner);

        void UpdateOrCreate(AuthAndApi.Authorization authorization);

    }

}
