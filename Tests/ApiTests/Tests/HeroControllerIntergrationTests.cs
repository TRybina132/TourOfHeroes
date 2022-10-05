using ApiTests.Comparers;
using ApiTests.Deserializers;
using ApiTests.Factories;
using DataAccess.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Presentation.ViewModels.Hero;
using Presentation.ViewModels.User;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace ApiTests.Tests
{
    public class HeroControllerIntergrationTests : IClassFixture<TestWebAppFactory<Program>>
    {
        //  ᓚᘏᗢ We need client to make requests
        private const string route = "/api/hero";
        private readonly HttpClient client;
        private readonly HeroViewModel exceptedHero = new HeroViewModel { Name = "Andromeda", Id = 200 };

        private void Login()
        {
            UserLoginViewModel login = new UserLoginViewModel
            {
                UserName = "nancy_2200",
                Password = "nancy20002"
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(login));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.PostAsync("/api/auth",content).Result;
            response.EnsureSuccessStatusCode();
        }

        //  ᓚᘏᗢ Here we're getting configured client for calls to our api
        public HeroControllerIntergrationTests(TestWebAppFactory<Program> factory)
        {
            client = factory.CreateClient();
            Login();
        }

        [Fact]
        public async Task GetAllHeroes_WhenHeroesExists()
        {
            HttpResponseMessage response = await client.GetAsync(route);
            
            //  ᓚᘏᗢ Throws a exception if is not successful
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            var heroes = JsonDeserializer<HeroViewModel>.DeserializeList(result);

            Assert.NotNull(heroes);
            Assert.True(heroes?.Count == 3);
        }

        [Fact]
        public async Task GetHeroById_WhenHeroExists() 
        {
            HttpResponseMessage httpResponseMessage = 
                await client.GetAsync($"{route}/{exceptedHero.Id}");

            string result = await httpResponseMessage.Content.ReadAsStringAsync();
            HeroViewModel? hero = JsonDeserializer<HeroViewModel>.DeserializeObject(result);

            Assert.NotNull(hero);
            Assert.Equal(exceptedHero, hero, new HeroViewModelComparer());
        }

        [Fact]
        public async Task GetHeroById_WhenHeroNotExists()
        {
            int heroId = 20;

            HttpResponseMessage response = await client.GetAsync($"{route}/{heroId}");

            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateHero()
        {
            HeroCreateViewModel hero = new HeroCreateViewModel
            {
                Name = "Eva_02"
            };

            StringContent serializedHero = new StringContent(JsonConvert.SerializeObject(hero));
            serializedHero.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(route, serializedHero);
            
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteHero()
        {
            int id = 400;
          
            HttpResponseMessage response = await client.DeleteAsync($"{route}/{id}");
            HttpResponseMessage deletedHero = await client.GetAsync($"{route}/{id}");

            Assert.True(deletedHero.StatusCode == HttpStatusCode.NotFound);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateHero()
        {
            HeroUpdateViewModel updatedHero = new HeroUpdateViewModel
            {
                Id = 200,
                Name = "Andromeda_super22"
            };

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(updatedHero));
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PutAsync(route, stringContent);
            HttpResponseMessage heroResponse = await client.GetAsync($"{route}/{updatedHero.Id}");

            string jsonHero = await heroResponse.Content.ReadAsStringAsync();
            HeroViewModel? heroViewModel = JsonConvert.DeserializeObject<HeroViewModel>(jsonHero);

            Assert.True(response.StatusCode == HttpStatusCode.OK);
            Assert.Equal(updatedHero.Name, heroViewModel?.Name);
            Assert.Equal(updatedHero.Id, heroViewModel?.Id);
        }
    }
}
