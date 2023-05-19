
using Microsoft.EntityFrameworkCore;
using ViSoft.Playground.Application.Data;
using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.Persistence.EF.Users
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly IAppDbContext _dbContext;

        public UserRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
        }

        public async Task<User?> GetByEmail(string emailAddress)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.EmailAddress == emailAddress);
          
            return user;
        }
    }
}
