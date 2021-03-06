﻿using System;
using System.Collections.Generic;


namespace AuthAndApi {

    // Note: The serivce class is really just a tool to look up drivers by name.
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

        //
        //

        public DriverContract GetDriver(string service) {

            DriverContract driver = null;

            if (!Drivers.TryGetValue(service, out driver))
                throw new NotSupportedException($"Unable to find service {service}.");

            return driver;

        }

        /*
        public void Associate(Owner owner, State state, object data) {
            GetDriver(state.Driver).Associate(owner, state, data);
        }

        public bool CanAuthenticate(State state, object data) {
            return GetDriver(state.Driver) is CanAuthenticate;
        }
        */

        //
        //

        /*
        public ResourceOwner GetResourceOwner(State state, object data) {
            return GetDriver(state.Driver).GetResourceOwner(state, data);
        }
        */

    }

}
