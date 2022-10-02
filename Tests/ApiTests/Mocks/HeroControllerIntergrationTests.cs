using ApiTests.Factories;
using System.Net.Http;
using Xunit;

namespace ApiTests.Mocks
{
    public class HeroControllerIntergrationTests : IClassFixture<TestWebAppFactory<Program>>
    {
        //  ᓚᘏᗢ We need client to make requests
        private readonly HttpClient client;

        public HeroControllerIntergrationTests(TestWebAppFactory<Program> factory) =>
            client = factory.CreateClient();

        [Fact]
        public async Task GetAllHeroesWhenHeroesExists()
        {
            HttpResponseMessage response = await client.GetAsync("/api/hero");
            
            //  ᓚᘏᗢ Throws a exception if is not successful
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            Assert.Contains("Andromeda", result);
        }
    }
}
