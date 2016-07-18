using NodaTime;


namespace AuthAndApi {

    public class Authorization {

        public int Id { get; set; }

        public Owner Owner { get; set; }

        public string DriverName { get; set; }

        public string Token { get; set; }

        public string Secret { get; set; }

        public string NativeId { get; set; }

        public string RefreshToken { get; set; }

        public ZonedDateTime? ExpiresAt { get; set; }

        public ZonedDateTime? LastCheckedAt { get; set; }

        public ZonedDateTime? LastRefreshedAt { get; set; }

        public ZonedDateTime? CreatedAt { get; set; }

        public ZonedDateTime? UpdatedAt { get; set; }

        //

        public bool IsExpired => LastCheckedAt?.ToDateTimeUtc().CompareTo(SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc()) < 0;

        public bool IsAssociated => Owner != null;

        //
        //

        public void Update(Authorization newAuthorization) {

            var now = SystemClock.Instance.GetCurrentInstant().InUtc();

            Token = newAuthorization.Token;
            Secret = newAuthorization.Secret;
            NativeId = newAuthorization.NativeId;
            ExpiresAt = newAuthorization.ExpiresAt;

            if(newAuthorization.RefreshToken != null) {
                RefreshToken = newAuthorization.RefreshToken;
                LastRefreshedAt = now;
            }

            LastCheckedAt = now;
            UpdatedAt = now;

        }

    }

}
