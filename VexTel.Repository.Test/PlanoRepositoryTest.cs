using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Entities;
using VexTel.Repository.Repositories;
using VexTel.Repository.Test.Contexto;
using Xunit;

namespace VexTel.Repository.Test
{
    public class PlanoRepositoryTest
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoRepositoryTest()
        {
            _planoRepository = new PlanoRepository(RepositoryDataContext.InstanceContext());
        }

        [Fact]
        public void Plano_Save_Changes_Is_Called()
        {
            var plano = new Plano
            {
                Id = 1,
                Descricao = "Falemais 30",
                TempoMinutos = 30,
                CustoAdicionalMinuto = 10
            };

            _planoRepository.Add(plano);
            var retorno = _planoRepository.GetById(1);

            //Assert  
            Assert.NotNull(retorno);
            Assert.IsAssignableFrom<Plano>(retorno);
        }
    }
}
