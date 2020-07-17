using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("api/health")]
        public IActionResult Heathle()
        {
            return Ok();
        }
    }
}