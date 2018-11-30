using System;
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

        [HttpGet("language/{teaching}/{learning}")]
        public async Task<IActionResult> GetCoursesByLanguageCode(string teaching, string learning)
        {
            return Ok(await _courseManager.GetCoursesByLanguageCodeAsync(teaching, learning));
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            bool success = await _courseManager.DeleteCourseAsync(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("test/{testId:int}")]
        public async Task<IActionResult> GetCourseByTestIdAsync(int testId)
        {
            return Ok(await _courseManager.GetCourseByTestIdAsync(testId));
        }
    }
}