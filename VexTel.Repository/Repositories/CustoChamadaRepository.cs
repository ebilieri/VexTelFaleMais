using System;
using System.Collections.Generic;
using System.Text;
using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Entities;
using VexTel.Repository.Context;

namespace VexTel.Repository.Repositories
{
    public class CustoChamadaRepository : BaseRepository<CustoChamada>, ICustoChamadaRepository
    {
        public CustoChamadaRepository(VexTelContext vexTelContext) : base(vexTelContext)
        {
        }
    }
}
