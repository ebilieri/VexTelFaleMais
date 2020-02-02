using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Entities;
using VexTel.Repository.Context;

namespace VexTel.Repository.Repositories
{
    public class PlanoRepository : BaseRepository<Plano>, IPlanoRepository
    {
        public PlanoRepository(VexTelContext vexTelContext) : base(vexTelContext)
        {
        }
    }
}
