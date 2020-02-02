using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Contracts.IServices;

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
    }
}
