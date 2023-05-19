namespace ViSoft.Playground.Domain.Users
{
    public class User
    {
        public Guid Id { get; init; }
        public string EmailAddress { get; init; } = string.Empty;
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;

        public static User Create(string emailAddress, string firstName, string lastName)
        {
            return new User
            {
                EmailAddress = emailAddress,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
