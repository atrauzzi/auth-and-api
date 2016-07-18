namespace AuthAndApi.Facebook {

    public struct OwnerMeta {

        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public OwnerMeta(string id, string firstName, string lastName, string email) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

    }

}
