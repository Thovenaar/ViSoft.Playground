using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.WebAPI.IntegrationTests.TestUtils.Factories
{
    public class UserFactory : BaseFactory
    {
        public override async Task SeedData()
        {
            var dbContext = GetAppDbContext();
            dbContext.Users.Add(new User
            {
                EmailAddress = "thomas@visoftsolutions.nl",
                FirstName = "Thomas",
                LastName = "Vieveen"
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
