using NodaTime;


namespace AuthAndApi {

    public class Authorization {

        public Owner Owner { get; set; }

        public string DriverId { get; set; }

        public string Token { get; set; }

        public string Secret { get; set; }

        public string NativeId { get; set; }

        public string RefreshToken { get; set; }

        public ZonedDateTime LastRefreshed { get; set; }

        public ZonedDateTime Expires { get; set; }

        public ZonedDateTime LastChecked { get; set; }

        public ZonedDateTime Created { get; set; }

        public bool Expired => LastChecked.ToDateTimeUtc().CompareTo(SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc()) < 0;

    }

}
