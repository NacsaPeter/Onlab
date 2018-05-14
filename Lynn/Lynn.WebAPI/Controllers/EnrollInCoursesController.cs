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
    public class EnrollInCoursesController
    {
        private readonly EnrollmentManager _manager;

        public EnrollInCoursesController()
        {
            _manager = new EnrollmentManager();
        }

        [HttpGet("{coursename}", Name = "GetCoursesByName")]
        public IEnumerable<Course> GetCoursesByName(string coursename)
        {
            return _manager.GetCoursesByName(coursename);
        }
    }
}
