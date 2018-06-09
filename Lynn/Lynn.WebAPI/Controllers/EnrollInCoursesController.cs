using Lynn.BLL;
using Lynn.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EnrollInCoursesController : Controller
    {
        private readonly EnrollmentManager _manager;

        public EnrollInCoursesController(EnrollmentManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{coursename}", Name = "GetCoursesByName")]
        public IActionResult GetCoursesByName(string coursename)
        {
            return Ok(_manager.GetCoursesByName(coursename));
        }
    }
}
