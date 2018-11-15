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
        private readonly UserManager _userManager;

        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            return Ok(await _userManager.GetUserByNameAsync(username));
        }

        [HttpGet("mycourses/{username}")]
        public async Task<IActionResult> GetMyCourses(string username)
        {
            return Ok(await _userManager.GetMyCoursesAsync(username));
        }
    }
}
