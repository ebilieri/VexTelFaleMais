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
    public class PlanosController: ControllerBase
    {
        private readonly IPlanoService _planoService;

        public PlanosController(IPlanoService planoService)
        {
            _planoService = planoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_planoService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Add(Plano plano)
        {
            try
            {
                _planoService.Add(plano);
                return Created("api/ddds", plano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
