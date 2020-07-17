using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Micro.Core.EventBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }
        [HttpGet]
        [Route("api/user")]
        public JsonResult GetDefaultUser()
        {
            return new JsonResult(new { username = "5003张三" });
        }
        [HttpGet]
        [Route("api/user/sub")]
        public IActionResult Eventbus()
        {      
            return Ok();
        }
    }
}