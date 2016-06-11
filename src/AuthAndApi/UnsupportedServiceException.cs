using System;

namespace AuthAndApi {

    internal class UnsupportedServiceException : Exception {

        public string Service { get; }

        public UnsupportedServiceException(string service) : base($"No driver found for {service}.") {
            Service = service;
        }

        public UnsupportedServiceException(string service, Exception innerException) : base($"No driver found for {service}", innerException) {
        }

    }

}