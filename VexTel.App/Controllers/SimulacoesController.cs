using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VexTel.Domain.Contracts.IServices;

namespace VexTel.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimulacoesController : ControllerBase
    {
        private readonly ISimulacaoChamadaService _simulacaoChamadaService;

        public SimulacoesController(ISimulacaoChamadaService simulacaoChamadaService)
        {
            _simulacaoChamadaService = simulacaoChamadaService;
        }
    }
}
