using NodaTime;


namespace AuthAndApi {

    public interface GenericAuthorizationContract<OwnerType> : AuthorizationContract where OwnerType : Owner {

        new OwnerType Owner { get; set; }

    }

}
