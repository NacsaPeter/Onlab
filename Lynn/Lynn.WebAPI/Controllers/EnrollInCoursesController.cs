using Lynn.BLL;
using Lynn.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EnrollInCoursesController : Controller
    {
        private readonly EnrollmentManager _manager;

        public EnrollInCoursesController(EnrollmentManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{coursename}")]
        public async Task<IActionResult> GetCoursesByName(string coursename)
        {
            return Ok(await _manager.GetCoursesByNameAsync(coursename));
        }
    }
}
