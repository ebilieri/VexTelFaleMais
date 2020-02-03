using VexTel.Domain.Entities;

namespace VexTel.Domain.Contracts.IServices
{
    public interface ICustoChamadaService : IBaseService<CustoChamada>
    {
        CustoChamada Get(int dDDOrigemId, int dDDDestinoId);
    }
}
