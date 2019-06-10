using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllCampsAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                //return BadRequest("Database Failure");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        private readonly ICampRepository _repository;

        public CampsController(ICampRepository repository)
        {
            _repository = repository;
        }
    }
}