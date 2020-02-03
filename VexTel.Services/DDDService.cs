using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;

namespace VexTel.Services
{
    public class DDDService : BaseService<DDD>, IDDDService
    {
        public DDDService(IBaseRepository<DDD> baseRepository) : base(baseRepository)
        {
        }
    }
}
