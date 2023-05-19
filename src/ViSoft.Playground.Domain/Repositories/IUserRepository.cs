using ViSoft.Playground.Domain.Entities;

namespace ViSoft.Playground.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser();
    }
}
