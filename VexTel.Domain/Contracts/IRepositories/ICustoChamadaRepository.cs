using VexTel.Domain.Entities;

namespace VexTel.Domain.Contracts.IRepositories
{
    public interface ICustoChamadaRepository : IBaseRepository<CustoChamada>
    {
        CustoChamada Get(int dDDOrigemId, int dDDDestinoId);
    }
}
