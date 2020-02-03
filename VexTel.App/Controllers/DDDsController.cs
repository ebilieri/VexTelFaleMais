using Microsoft.AspNetCore.Mvc;
using System;
using VexTel.Domain.Contracts.IServices;
using VexTel.Domain.Entities;

namespace VexTel.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DDDsController: ControllerBase
    {
        private readonly IDDDService _DDDService;

        public DDDsController(IDDDService DDDService)
        {
            _DDDService = DDDService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_DDDService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Add(DDD ddd)
        {
            try
            {
                _DDDService.Add(ddd);
                return Created("api/ddds", ddd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
