using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lynn.BLL;
using Lynn.BLL.Interfaces;
using Lynn.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentManager _enrollmentManager;

        public EnrollmentController(IEnrollmentManager enrollmentManager)
        {
            _enrollmentManager = enrollmentManager;
        }

        [HttpPost]
        public async Task<IActionResult> EnrollCourse([FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest();
            }

            var created = await _enrollmentManager.EnrollCourseAsync(enrollment);

            if (created == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetEnrollmentById), new { created.Id }, created);
        }

        [HttpGet("{id}", Name = "GetEnrollmentById")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentManager.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpGet("{userId}/{courseId}", Name = "GetEnrollment")]
        public async Task<IActionResult> GetEnrollment(int userId, int courseId)
        {
            var enrollment = await _enrollmentManager.GetEnrollmentAsync(userId, courseId);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }
    }
}
