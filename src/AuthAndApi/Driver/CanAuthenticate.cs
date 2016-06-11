namespace AuthAndApi.Driver {

    public interface CanAuthenticate {

        Owner FindOrCreateOwner(object data);

    }

}
