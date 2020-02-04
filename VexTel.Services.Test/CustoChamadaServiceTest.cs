using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;
using Xunit;

namespace VexTel.Services.Test
{
    [ExcludeFromCodeCoverage]
    public class CustoChamadaServiceTest
    {
        private readonly Mock<ICustoChamadaRepository> _custoChamadaRepositoryMock;
        private readonly ICustoChamadaService _serviceMock;

        public CustoChamadaServiceTest()
        {
            _custoChamadaRepositoryMock = new Mock<ICustoChamadaRepository>();
            _serviceMock = new CustoChamadaService(_custoChamadaRepositoryMock.Object);
        }

        [Fact]
        public void CustoChamadaService_GetById_Return_Be_Sucess()
        {
            _custoChamadaRepositoryMock.Setup(x => x.GetById(1)).Returns(new CustoChamada
            {
                Id = 1,
                DDDOrigemId = 1,
                DDDDestinoId = 2,
                CustoMinuto = 1.9M
            });
            
            var ddd = _serviceMock.GetById(1);

            _custoChamadaRepositoryMock.Verify(r => r.GetById(
                It.Is<int>(v => v == ddd.Id)));
        }


        [Fact]
        public void CustoChamadaService_Add_Return_Be_Sucess()
        {
            var custoChamada = new CustoChamada
            {
                Id = 1,
                DDDOrigemId = 1,
                DDDDestinoId = 2,
                CustoMinuto = 1.9M
            };
           
            _serviceMock.Add(custoChamada);

            _custoChamadaRepositoryMock.Verify(r => r.Add(
             It.Is<CustoChamada>(v => v.Id == custoChamada.Id)));
        }

        [Fact]
        public void CustoChamadaService_Add_Return_ThrowsException()
        {
            var custoChamada = new CustoChamada
            {
                Id = 1,
                DDDOrigemId = 1,
                DDDDestinoId = 1,
                CustoMinuto = 1.9M
            };
                        
            Assert.Throws<Exception>(() => _serviceMock.Add(custoChamada));            
        }
    }
}
