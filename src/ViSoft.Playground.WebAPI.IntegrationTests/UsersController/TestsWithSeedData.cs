using FluentAssertions;
using Newtonsoft.Json;
using ViSoft.Playground.Domain.Users;
using ViSoft.Playground.WebAPI.IntegrationTests.TestUtils;
using ViSoft.Playground.WebAPI.IntegrationTests.TestUtils.Factories;

namespace ViSoft.Playground.WebAPI.IntegrationTests.UsersController
{
    [Collection(SharedTestCollections.UserCollection)]
    public class TestsWithSeedData
    {
        private readonly HttpClient _client;

        public TestsWithSeedData(UserFactory userFactory)
        {
            _client = userFactory.CreateClient();
        }

        [Fact]
        public async Task GetUsers_ReturnsUsers()
        {
            var response = await _client.GetAsync("api/v1/User/GetByEmailAddress?emailAddress=thomas@visoftsolutions.nl");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(json);

            user.Should().NotBeNull();
            user.FirstName.Should().Be("Thomas");
            user.LastName.Should().Be("Vieveen");
        }
    }
}
