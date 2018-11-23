﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lynn.BLL.Interfaces;
using Lynn.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CourseController : Controller
    {
        private readonly ICourseManager _courseManager;

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet("enrolled/{id:int}")]
        public async Task<IActionResult> GetEnrolledCoursesByUserId(int id)
        {
            return Ok(await _courseManager.GetEnrolledCoursesAsync(id));
        }

        [HttpGet("name/{coursename}")]
        public async Task<IActionResult> GetCoursesByName(string coursename)
        {
            return Ok(await _courseManager.GetCoursesByNameAsync(coursename));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseAsync([FromBody]Course course)
        {
            return Ok(await _courseManager.CreateCourseAsync(course));
        }

        [HttpPut]
        public async Task<IActionResult> EditCourseAsync([FromBody]Course course)
        {
            throw new NotImplementedException();
        }
    }
}