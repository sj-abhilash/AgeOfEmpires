using AgeOfEmpires.Entities;
using AgeOfEmpires.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeOfEmpires.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IBattleService _battleservice;

        public BattleController(IBattleService battleservice)
        {
            _battleservice = battleservice;
        }

        [HttpGet]
        public async Task<ActionResult> GetUnitsBattle()
        {
            var result = await _battleservice.GetUnitsBattle();
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in getting the Units Battle result");
            return Ok(result);
        }
    }
}
