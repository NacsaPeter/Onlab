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

            var created = _manager.EnrollCourse(enrollment);

            if (created == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetEnrollmentById), new { created.ID }, created);
        }

        [HttpGet("{id}", Name = "GetEnrollmentById")]
        public IActionResult GetEnrollmentById(int id)
        {
            return Ok(_manager.GetEnrollmentById(id));
        }


    }
}
