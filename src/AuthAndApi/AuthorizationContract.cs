using NodaTime;


namespace AuthAndApi {

    public interface AuthorizationContract {

        Owner Owner { get; set; }

        string DriverId { get; set; }

        string Token { get; set; }

        string Secret { get; set; }

        string NativeId { get; set; }

        string RefreshToken { get; set; }

        ZonedDateTime LastRefreshed { get; set; }

        ZonedDateTime Expires { get; set; }

        ZonedDateTime LastChecked { get; set; }

        ZonedDateTime Created { get; set; }

        bool Expired { get; }
        //public bool Expired => LastChecked.ToDateTimeUtc().CompareTo(SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc()) < 0;

    }

}
