using Microsoft.AspNetCore.Mvc;
using System;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;

namespace VexTel.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustoChamadasController : ControllerBase
    {
        private readonly ICustoChamadaService _custoChamadaServiceService;

        public CustoChamadasController(ICustoChamadaService custoChamadaService)
        {
            _custoChamadaServiceService = custoChamadaService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_custoChamadaServiceService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Add(CustoChamada custoChamada)
        {
            try
            {
                _custoChamadaServiceService.Add(custoChamada);
                return Created("api/ddds", custoChamada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
