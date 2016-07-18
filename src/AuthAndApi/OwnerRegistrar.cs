using System;


namespace AuthAndApi {

    public interface OwnerRegistrar {

        Owner Create(ValueType ownerMeta, Authorization authorization);

    }

}
