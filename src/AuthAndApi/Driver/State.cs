using System;


namespace AuthAndApi.Driver {

    public abstract class State {

        public string Driver { get; protected set; }

        public string Key { get; protected set; }

    }

}
