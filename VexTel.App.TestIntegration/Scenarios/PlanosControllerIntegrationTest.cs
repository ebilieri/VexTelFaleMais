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
    public class PlanosControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PlanosControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task Get_Returns_Ok_Response()
        {
            var response = await _client.GetAsync("/api/planos");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_Returns_Created_Response()
        {
            var plano = new Plano
            {
                Descricao = "FaleMais 200",
                TempoMinutos = 200,
                CustoAdicionalMinuto = 10
            };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(plano), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/planos");            
            postRequest.Content = httpContent;

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
