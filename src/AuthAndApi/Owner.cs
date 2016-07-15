using System.Collections.Generic;


namespace AuthAndApi {

    public interface Owner {

        ISet<Authorization> Authorizations { get; set; }

    }

}
