using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lynn.BLL;
using Lynn.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EnrollmentController : Controller
    {
        private readonly EnrollmentManager _manager;

        public EnrollmentController(EnrollmentManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> EnrollCourse([FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest();
            }

            var created = await _manager.EnrollCourseAsync(enrollment);

            if (created == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetEnrollmentById), new { created.ID }, created);
        }

        [HttpGet("{id}", Name = "GetEnrollmentById")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _manager.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }


    }
}
