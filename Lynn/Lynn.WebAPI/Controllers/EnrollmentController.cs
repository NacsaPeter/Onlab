using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lynn.BLL;
using Lynn.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly EnrollmentManager manager;

        public EnrollmentController()
        {
            manager = new EnrollmentManager();
        }

        [HttpPost]
        public IActionResult EnrollCourse([FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest();
            }

            int enrollmentId = manager.EnrollCourse(enrollment);

            return Json(enrollmentId);
            //return Created();
        }

        [HttpGet("{coursename}", Name = "GetCoursesByName")]
        public IEnumerable<Course> GetCoursesByName(string coursename)
        {
            return manager.GetCoursesByName(coursename);
        }
    }
}
