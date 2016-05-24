using NodaTime;


namespace AuthAndApi {

    public class Authorization {

        public int DriverId { get; }

        public Owner Owner { get; }

        public string Token { get; }

        public string Secret { get; }

        public string NativeId { get; }

        public string RefreshToken { get; }

        public ZonedDateTime LastRefreshed { get; }

        public ZonedDateTime Expires { get; }

        public ZonedDateTime LastChecked { get; }

        public ZonedDateTime Created { get; }

        //

        public bool Stale {
            get {
                return LastChecked.ToDateTimeUtc().CompareTo(SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc()) < 0;
            }
        }

    }

}
