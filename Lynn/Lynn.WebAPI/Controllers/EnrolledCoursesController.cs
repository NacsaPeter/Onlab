﻿using Lynn.BLL;
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
        private readonly EnrollmentManager _manager;

        public EnrolledCoursesController(EnrollmentManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id:int}", Name = "GetEnrolledCoursesByUserId")]
        public IActionResult GetEnrolledCoursesByUserId(int id)
        {
            return Ok(_manager.GetEnrolledCourses(id));
        }
    }
}
