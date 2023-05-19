using System.Net;
using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using ViSoft.Playground.Domain.Users;
using ViSoft.Playground.WebAPI.IntegrationTests.TestUtils;
using ViSoft.Playground.WebAPI.IntegrationTests.TestUtils.Factories;

namespace ViSoft.Playground.WebAPI.IntegrationTests.UsersController
{
    [Collection(SharedTestCollections.GenericCollection)]
    public class TestsWithoutSeedData
    {
        private readonly HttpClient _client;

        public TestsWithoutSeedData(GenericFactory genericFactory)
        {
            _client = genericFactory.CreateClient();
        }

        [Fact]
        public async Task WhenRegisteringUser_ItShouldReturnValidUser()
        {
            // Arrange
            var newUser = new User
            {
                EmailAddress = "thomas@visoftsolutions.nl",
                FirstName = "Thomas",
                LastName = "Vieveen"
            };

            // Act
            var postResponse = await _client.PostAsync("api/v1/User/Register", new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json"));
            var response = await _client.GetAsync("api/v1/User/GetByEmailAddress?emailAddress=thomas@visoftsolutions.nl");

            // Assert
            postResponse.EnsureSuccessStatusCode();
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(json);

            user.Should().NotBeNull();
            user.EmailAddress.Should().Be("thomas@visoftsolutions.nl");
            user.FirstName.Should().Be("Thomas");
            user.LastName.Should().Be("Vieveen");
        }

        [Fact]
        public async Task WhenUserDoesNotExists_ItShouldReturn404()
        {
            // Act
            var response = await _client.GetAsync("api/v1/User/GetByEmailAddress?emailAddress=thomas2@visoftsolutions.nl");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
