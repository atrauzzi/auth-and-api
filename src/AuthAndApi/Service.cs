using System;
using System.Collections.Generic;
using DriverContract = AuthAndApi.Driver.Contract;


namespace AuthAndApi {

    public class Service {

        // This: http://stackoverflow.com/questions/1437902/structuremap-constructor-that-takes-a-list-of-plugins
        // Plus this: http://stackoverflow.com/questions/19795980/how-to-retrieve-the-names-of-all-the-named-instances-in-structuremap
        // Food for thought: https://codetype.wordpress.com/2012/06/18/using-structuremap-to-collect-and-use-all-instances-of-a-given-type/
        // Reminder: https://twitter.com/jeremydmiller/status/741754579092545536
        // ToDo: Make immutable!
        public IDictionary<string, DriverContract> Drivers { get; protected set; }

        public Service(IDictionary<string, DriverContract> drivers) {
            Drivers = drivers;
        }

        public State Start(DriverContract driver, Uri returnUri = null) {

            Uri authorizationUri = null;
            string stateKey = null;

            authorizationUri = driver.GetAuthorizationUri(out stateKey, returnUri);
            
            return new State(driver.Name, authorizationUri, stateKey);

        }

        public State Start(string service, Uri returnUri = null) {

            DriverContract driver = null;

            if(!Drivers.TryGetValue(service, out driver))
                throw new UnsupportedServiceException(service);

            return Start(driver, returnUri);

        }

    }

}
