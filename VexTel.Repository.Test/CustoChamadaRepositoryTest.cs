using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Entities;
using VexTel.Repository.Repositories;
using VexTel.Repository.Test.Contexto;
using Xunit;

namespace VexTel.Repository.Test
{
    public class CustoChamadaRepositoryTest
    {       
        private readonly ICustoChamadaRepository _custoChamadaRepository;

        public CustoChamadaRepositoryTest()
        {
            _custoChamadaRepository = new CustoChamadaRepository(RepositoryDataContext.InstanceContext());
        }

        [Fact]
        public void CustoChamada_Save_Changes_Is_Called()
        {            
            var custoChamada = new CustoChamada
            {
                Id = 1,
                DDDOrigemId = 1,
                DDDDestinoId = 2,
                CustoMinuto = 1.90M
            };

            _custoChamadaRepository.Add(custoChamada);
            var retorno = _custoChamadaRepository.GetById(1);

            //Assert  
            Assert.NotNull(retorno);
            Assert.IsAssignableFrom<CustoChamada>(retorno);
        }
    }
}
