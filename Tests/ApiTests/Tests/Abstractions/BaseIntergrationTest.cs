using ApiTests.Factories;
using Newtonsoft.Json;
using Presentation.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.Tests.Abstractions
{
    public abstract class BaseIntergrationTests : IClassFixture<TestWebAppFactory<Program>>
    {
        protected readonly HttpClient client;

        protected void Login()
        {
            UserLoginViewModel login = new UserLoginViewModel
            {
                UserName = "nancy_2200",
                Password = "nancy20002"
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(login));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.PostAsync("/api/auth", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public BaseIntergrationTests(TestWebAppFactory<Program> factory)
        {
            client = factory.CreateClient();
            Login();
        }
    }
}
