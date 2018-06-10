using Lynn.BLL;
using Lynn.DTO;
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
    public class EnrolledCoursesController : Controller
    {
        private readonly EnrollmentManager _manager;

        public EnrolledCoursesController(EnrollmentManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEnrolledCoursesByUserId(int id)
        {
            return Ok(_manager.GetEnrolledCourses(id));
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetEnrolledCoursesByUserIdV2(int id)
        {
            var courses = _manager.GetEnrolledCourses(id);
            int count = 0;
            foreach (var item in courses)
            {
                count++;
            }
            return Ok(new { count, courses });
        }
    }
}
