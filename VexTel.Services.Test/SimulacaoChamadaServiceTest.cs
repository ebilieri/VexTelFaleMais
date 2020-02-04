using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;
using Xunit;

namespace VexTel.Services.Test
{
    [ExcludeFromCodeCoverage]
    public class SimulacaoChamadaServiceTest
    {        
        private readonly Mock<IDDDService> _dddServiceMock;
        private readonly Mock<IPlanoService> _planoServiceMock;
        private readonly Mock<ICustoChamadaService> _custoChamadaServiceMock;        

        public SimulacaoChamadaServiceTest()
        {
            _dddServiceMock = new Mock<IDDDService>();
            _planoServiceMock = new Mock<IPlanoService>();
            _custoChamadaServiceMock = new Mock<ICustoChamadaService>();           
        }

        [Theory]
        [InlineData(1, 2, 1, 20, 0, 38.00)]
        [InlineData(1, 3, 2, 80, 37.40, 136)]
        [InlineData(2, 3, 1, 100, 0, 0)]
        public void Simular_Return_Be_Success(int dddOrigemId, int dddDestinoId, 
                                                int planoId, 
                                                int tempo, 
                                                decimal comFaleMais, decimal semFaleMais)
        {
            var simulacao = new SimulacaoChamada
            {
                DDDOrigemId = dddOrigemId,
                DDDDestinoId = dddDestinoId,
                PlanoId = planoId,
                Tempo = tempo
            };

            var veiculoService = new SimulacaoChamadaService(_dddServiceMock.Object,
                                                            _planoServiceMock.Object,
                                                            _custoChamadaServiceMock.Object);
            BindDDDs();
            BindPlanos();
            BindCustoChamadas();

            veiculoService.Simular(simulacao);

            Assert.Equal(comFaleMais, Convert.ToDecimal(simulacao.CustoComFaleMais));
            Assert.Equal(semFaleMais, Convert.ToDecimal(simulacao.CustoSemFaleMais));

        }

        private void BindCustoChamadas()
        {
            var custoChamada1 = new CustoChamada
            {
                Id = 1,
                DDDOrigemId = 1,
                DDDDestinoId = 2,
                CustoMinuto = 1.9M
            };
            var custoChamada2 = new CustoChamada
            {
                Id = 2,
                DDDOrigemId = 1,
                DDDDestinoId = 3,
                CustoMinuto = 1.7M
            };

            _custoChamadaServiceMock.Setup(x => x.Get(1, 2)).Returns(custoChamada1);
            _custoChamadaServiceMock.Setup(x => x.Get(1, 3)).Returns(custoChamada2);
        }

        private void BindPlanos()
        {
            var plano1 = new Plano
            {
                Id = 1,
                Descricao = "Falemais 30",
                TempoMinutos = 30,
                CustoAdicionalMinuto = 10
            };
            var plano2 = new Plano
            {
                Id = 2,
                Descricao = "Falemais 60",
                TempoMinutos = 60,
                CustoAdicionalMinuto = 10
            };

            _planoServiceMock.Setup(x => x.GetById(1)).Returns(plano1);
            _planoServiceMock.Setup(x => x.GetById(2)).Returns(plano2);
        }

        private void BindDDDs()
        {
            var ddd1 = new DDD
            {
                Id = 1,
                Codigo = "011"
            };
            var ddd2 = new DDD
            {
                Id = 2,
                Codigo = "016"
            };
            var ddd3 = new DDD
            {
                Id = 2,
                Codigo = "016"
            };

            _dddServiceMock.Setup(x => x.GetById(1)).Returns(ddd1);
            _dddServiceMock.Setup(x => x.GetById(2)).Returns(ddd2);
            _dddServiceMock.Setup(x => x.GetById(3)).Returns(ddd3);
        }
    }
}
