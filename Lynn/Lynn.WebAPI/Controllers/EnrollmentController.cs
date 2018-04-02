﻿using System;
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

        [HttpGet("{id}", Name = "GetEnrollments")]
        public IEnumerable<Course> GetEnrollmentsByUserId(int id)
        {
            return manager.GetEnrolledCourses(id);
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
        }
    }
}