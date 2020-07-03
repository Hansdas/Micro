using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Route("api/user")]
        public JsonResult GetDefaultUser()
        {
            return new JsonResult(new { username = "5003张三" });
        }
        [HttpGet]
        [Route("api/user/{username}")]

        public JsonResult GetDefaultUser(string username)
        {
            return new JsonResult(new { username = username });
        }
        [HttpGet("api/health")]
        public IActionResult Heathle()
        {
            return Ok();
        }
    }
}