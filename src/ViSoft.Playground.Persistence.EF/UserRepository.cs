
using Microsoft.EntityFrameworkCore;
using ViSoft.Playground.Domain.Entities;
using ViSoft.Playground.Domain.Repositories;

namespace ViSoft.Playground.Persistence.EF
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<User> GetUser()
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new InvalidOperationException("User not found");
            }

            var user = new User
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };

            return user;
        }
    }
}
