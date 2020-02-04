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
    public class CustoChamadasControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CustoChamadasControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task Get_Returns_Ok_Response()
        {
            var response = await _client.GetAsync("/api/custochamadas");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_Returns_Created_Response()
        {
            var ddd = new CustoChamada
            {
                DDDOrigemId = 1,
                DDDDestinoId = 2,
                CustoMinuto = 2.5M
            };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(ddd), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/custochamadas");            
            postRequest.Content = httpContent;

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
