using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Micro.Core.EventBus;
using Micro.Services.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
 
    [ApiController]
    public class UserController : ControllerBase
    {
        private IEventBus _eventBus;
        public UserController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        [HttpGet]
        [Route("api/user")]
        public JsonResult GetDefaultUser()
        {
            return new JsonResult(new { username = "5001张三" });
        }
        [HttpGet]
        [Route("api/user/eventbus")]
        public IActionResult Eventbus()
        {
            CreateUserEvent user = new CreateUserEvent();
            user.Name = "hanh";
            user.Address = "hubei";
            user.CreateTime = DateTime.Now;
            _eventBus.Publish(user);
            return Ok("ok");
        }
      
    }
}