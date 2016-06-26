using System.Collections.Generic;


namespace AuthAndApi {

    public interface Owner {

        ISet<AuthorizationContract> Authorizations { get; set; }

    }

}
