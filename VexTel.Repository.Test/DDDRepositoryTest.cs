using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Entities;
using VexTel.Repository.Repositories;
using VexTel.Repository.Test.Contexto;
using Xunit;

namespace VexTel.Repository.Test
{
    public class DDDRepositoryTest
    {       
        private readonly IDDDRepository _dddRepository;

        public DDDRepositoryTest()
        {
            _dddRepository = new DDDRepository(RepositoryDataContext.InstanceContext());
        }

        [Fact]
        public void DDD_Save_Changes_Is_Called()
        {            
            var ddd = new DDD
            {
                Id = 1,
                Codigo = "011"
            };
            
            _dddRepository.Add(ddd);
            var retorno = _dddRepository.GetById(1);

            //Assert  
            Assert.NotNull(retorno);
            Assert.IsAssignableFrom<DDD>(retorno);
        }
    }
}
