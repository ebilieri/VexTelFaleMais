using FluentAssertions;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VexTel.App.TestIntegration.Fixtures;
using VexTel.Domain.Entities;
using Xunit;

namespace VexTel.App.TestIntegration.Scenarios
{
    [ExcludeFromCodeCoverage]
    public class SimulacoesControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public SimulacoesControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_Returns_OK_Response_Simular()
        {
            var simulacaoChamada = new SimulacaoChamada
            {
                DDDOrigemId = 1,
                DDDDestinoId = 2,
                PlanoId = 1,
                Tempo = 30
            };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(simulacaoChamada), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/simulacoes/simular");   
            postRequest.Content = httpContent;

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);            
        }
    }
}
