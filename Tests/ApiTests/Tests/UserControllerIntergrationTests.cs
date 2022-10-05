using ApiTests.Factories;
using ApiTests.Tests.Abstractions;
using System.Net;
using Xunit;

namespace ApiTests.Tests
{
    public class UserControllerIntergrationTests : BaseIntergrationTests
    {
        private const string route = "api/user";

        public UserControllerIntergrationTests(TestWebAppFactory<Program> factory)
            : base(factory) { }

        [Fact]
        public async Task GetAllUsers()
        {
            HttpResponseMessage response = await client.GetAsync(route);

            string usersJson = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == HttpStatusCode.OK);            
        }
    }
}
