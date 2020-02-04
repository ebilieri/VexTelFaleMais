using Moq;
using System.Diagnostics.CodeAnalysis;
using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;
using Xunit;

namespace VexTel.Services.Test
{
    [ExcludeFromCodeCoverage]
    public class PlanoServiceTest
    {
        private readonly Mock<IPlanoRepository> _planoRepository;
        private readonly IPlanoService _serviceMock;

        public PlanoServiceTest()
        {
            _planoRepository = new Mock<IPlanoRepository>();
            _serviceMock = new PlanoService(_planoRepository.Object);
        }

        [Fact]
        public void DDDService_GetById_Return_Be_Sucess()
        {
            _planoRepository.Setup(x => x.GetById(1)).Returns(new Plano
            {
                Id = 1,
                Descricao = "Falemais 30",
                TempoMinutos = 30,
                CustoAdicionalMinuto = 10
            });
            
            var ddd = _serviceMock.GetById(1);

            _planoRepository.Verify(r => r.GetById(
                It.Is<int>(v => v == ddd.Id)));
        }

        [Fact]
        public void DDDService_Add_Return_Be_Sucess()
        {
            var plano = new Plano
            {
                Id = 1,
                Descricao = "Falemais 30",
                TempoMinutos = 30,
                CustoAdicionalMinuto = 10
            };
            
            _serviceMock.Add(plano);

            _planoRepository.Verify(r => r.Add(
                It.Is<Plano>(v => v.Descricao == plano.Descricao)));

        }
    }
}
