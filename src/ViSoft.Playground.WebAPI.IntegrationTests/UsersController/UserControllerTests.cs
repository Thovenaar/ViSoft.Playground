using FluentAssertions;
using Newtonsoft.Json;
using ViSoft.Playground.Domain.Entities;

namespace ViSoft.Playground.WebAPI.IntegrationTests.UsersController
{
    public class UserControllerTests : IClassFixture<UserFactory>
    {
        private readonly HttpClient _client;

        public UserControllerTests(UserFactory userFactory)
        {
            _client = userFactory.CreateClient();
        }

        [Fact]
        public async Task GetUsers_ReturnsUsers()
        {
            var response = await _client.GetAsync("api/v1/User/Get");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(json);

            user.Should().NotBeNull();
            user.FirstName.Should().Be("Thomas");
            user.LastName.Should().Be("Vieveen");
        }
    }
}
