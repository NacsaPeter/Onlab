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
    public class EnrolledCoursesController : Controller
    {
        private readonly EnrolledCoursesManager _manager;

        public EnrolledCoursesController(EnrolledCoursesManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id}", Name = "GetEnrolledCoursesByUserId")]
        public IEnumerable<Course> GetEnrolledCoursesByUserId(int id)
        {
            return _manager.GetEnrolledCourses(id);
        }
    }
}
