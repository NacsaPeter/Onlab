using Lynn.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : Controller
    {
        private readonly EnrollmentManager _manager;

        public UserController(EnrollmentManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            return Ok(_manager.GetUserByName(username));
        }
    }
}
