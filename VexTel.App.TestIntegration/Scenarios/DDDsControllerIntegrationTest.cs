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
    public class DDDsControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public DDDsControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task Get_Returns_Ok_Response()
        {
            var response = await _client.GetAsync("/api/ddds");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_Returns_Created_Response()
        {
            var ddd = new DDD
            {
                Codigo = "027"
            };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(ddd), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/ddds");            
            postRequest.Content = httpContent;

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
