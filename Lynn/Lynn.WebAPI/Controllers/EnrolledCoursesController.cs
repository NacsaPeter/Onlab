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
    public class EnrolledCoursesController : Controller
    {
        private readonly EnrollmentManager _manager;

        public EnrolledCoursesController(EnrollmentManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEnrolledCoursesByUserId(int id)
        {
            return Ok(await _manager.GetEnrolledCoursesAsync(id));
        }
    }
}
