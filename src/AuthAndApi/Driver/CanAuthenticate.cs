using AuthAndApi;


namespace Bitmoss.DataSource.Driver {

    interface CanAuthenticate {

        Owner FindOrCreateOwner(object data);

    }

}
