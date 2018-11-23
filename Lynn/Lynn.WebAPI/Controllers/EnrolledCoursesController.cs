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
    public class EnrolledCoursesController : Controller
    {
        private readonly ICourseManager _courseManager;

        public EnrolledCoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEnrolledCoursesByUserId(int id)
        {
            return Ok(await _courseManager.GetEnrolledCoursesAsync(id));
        }
    }
}
