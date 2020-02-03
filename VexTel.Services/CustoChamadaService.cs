using System;
using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;

namespace VexTel.Services
{
    public class CustoChamadaService : BaseService<CustoChamada>, ICustoChamadaService
    {
        public CustoChamadaService(IBaseRepository<CustoChamada> baseRepository) : base(baseRepository)
        {
        }

        public override void Add(CustoChamada entity)
        {
            if (entity.DDDOrigemId == entity.DDDDestinoId)
            {
                throw new Exception("O DDD de Destino deve ser diferente do DDD de Origem");
            }

            base.Add(entity);
        }
    }
}
