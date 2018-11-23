using Lynn.BLL;
using Lynn.BLL.Interfaces;
using Lynn.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EnrollInCoursesController : Controller
    {
        private readonly ICourseManager _courseManager;

        public EnrollInCoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet("{coursename}")]
        public async Task<IActionResult> GetCoursesByName(string coursename)
        {
            return Ok(await _courseManager.GetCoursesByNameAsync(coursename));
        }
    }
}
