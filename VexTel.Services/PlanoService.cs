using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;

namespace VexTel.Services
{
    public class PlanoService : BaseService<Plano>, IPlanoService
    {
        public PlanoService(IBaseRepository<Plano> baseRepository) : base(baseRepository)
        {
        }
    }
}
