namespace ViSoft.Playground.Domain.Entities
{
    public class User
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
    }
}
