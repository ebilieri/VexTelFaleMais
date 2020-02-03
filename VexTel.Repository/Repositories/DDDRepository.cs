using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Entities;
using VexTel.Repository.Context;

namespace VexTel.Repository.Repositories
{
    public class DDDRepository : BaseRepository<DDD>, IDDDRepository
    {
        public DDDRepository(VexTelContext vexTelContext) : base(vexTelContext)
        {
        }
    }
}
