using ViSoft.Playground.Persistence.EF.Models;

namespace ViSoft.Playground.WebAPI.IntegrationTests
{
    public class UserFactory : BaseFactory
    {
        public override async Task SeedData()
        {
            var dbContext = GetAppDbContext();
            dbContext.Users.Add(new User
            {
                FirstName = "Thomas",
                LastName = "Vieveen"
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
