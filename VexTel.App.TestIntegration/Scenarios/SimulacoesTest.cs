using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using VexTel.App.TestIntegration.Fixtures;
using Xunit;
using VexTel.Domain.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace VexTel.App.TestIntegration.Scenarios
{
    public class SimulacoesTest
    {
        private readonly TestContext _testContext;
        public SimulacoesTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            SimulacaoChamada simulacaoChamada = new SimulacaoChamada
            {
                DDDOrigemId = 1,
                DDDDestinoId = 2,
                PlanoId = 1,
                Tempo = 30
            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(simulacaoChamada), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _testContext.Client.PostAsync("api/simulacoes/simular", httpContent);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
