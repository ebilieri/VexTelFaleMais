using System;
using System.Collections.Generic;
using System.Text;
using VexTel.Domain.Entities;

namespace VexTel.Domain.Contracts.IServices
{
    public interface ICustoChamadaService : IBaseService<CustoChamada>
    {
        CustoChamada Get(int dDDOrigemId, int dDDDestinoId);
    }
}
