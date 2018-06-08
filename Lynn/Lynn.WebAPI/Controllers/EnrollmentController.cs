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
        private readonly EnrollmentManager _manager;

        public EnrollmentController(EnrollmentManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public IActionResult EnrollCourse([FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest();
            }

            int enrollmentId = _manager.EnrollCourse(enrollment);
            Uri url = new Uri($"http://localhost:56750/api/enrollment/{enrollmentId}");

            return Created(url, enrollmentId);
        }

        [HttpGet("{id}", Name = "GetEnrollmentById")]
        public Enrollment GetEnrollmentById(int id)
        {
            return _manager.GetEnrollmentById(id);
        }


    }
}
