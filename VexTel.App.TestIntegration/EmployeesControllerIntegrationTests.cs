using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VexTel.Domain.Entities;
using Xunit;

namespace VexTel.App.TestIntegration
{
    public class EmployeesControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public EmployeesControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_WhenPOSTExecuted_ReturnsToIndexViewWithCreatedEmployee()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/simulacoes/simular");

            //var formModel = new Dictionary<string, string>
            //{
            //    { "dddOrigemId", "1" },
            //    { "dddDestinoId", "2" },
            //    { "PlanoId", "1" }
            //};

            //postRequest.Content = new FormUrlEncodedContent(formModel);

            SimulacaoChamada simulacaoChamada = new SimulacaoChamada
            {
                DDDOrigemId = 1,
                DDDDestinoId = 2,
                PlanoId = 1,
                Tempo = 30
            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(simulacaoChamada), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            postRequest.Content = httpContent;

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //var responseString = await response.Content.ReadAsStringAsync();

           // Assert.Contains("New Employee", responseString);
            //Assert.Contains("214-5874986532-21", responseString);
        }
    }
}
