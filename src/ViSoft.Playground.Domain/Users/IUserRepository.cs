namespace ViSoft.Playground.Domain.Users
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<User?> GetByEmail(string emailAddress);
    }
}
