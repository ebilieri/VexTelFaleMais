using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("simular")]
        public ActionResult Simular(SimulacaoChamada simulacaoChamada)
        {
            try
            {                
                _simulacaoChamadaService.Simular(simulacaoChamada);
                return Ok(simulacaoChamada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
