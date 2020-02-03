using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;

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

        [HttpPost]
        public ActionResult Simular(SimulacaoChamada simulacaoChamada)
        {
            try
            {
                //simulacaoChamada.
                _simulacaoChamadaService.Simular(simulacaoChamada);
                return Ok(simulacaoChamada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
