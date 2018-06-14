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
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
            return Ok(await _manager.GetCoursesByName(coursename));
        }

        [HttpGet("{coursename}")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetCoursesByNameV2(string coursename)
        {
            var courses = await _manager.GetCoursesByName(coursename);
            return Ok(new { courses.Count, courses });
        }
    }
}
