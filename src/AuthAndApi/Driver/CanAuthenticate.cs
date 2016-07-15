namespace AuthAndApi.Driver {

    public interface CanAuthenticate : Contract {

        Owner FindOwner(Authorization authorization);

        Owner CreateOwner(Authorization authorization);

    }

}
