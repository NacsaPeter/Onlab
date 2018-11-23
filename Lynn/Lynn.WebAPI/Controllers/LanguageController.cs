using Lynn.BLL;
using Lynn.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class LanguageController : Controller
    {
        private readonly ILanguageManager _languageManager;
        private readonly IEnrollmentManager _enrollmentManager;
        private readonly ICourseManager _courseManager;

        public LanguageController(
            ILanguageManager languageManager,
            IEnrollmentManager enrollmentManager,
            ICourseManager courseManager)
        {
            _languageManager = languageManager;
            _enrollmentManager = enrollmentManager;
            _courseManager = courseManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetLanguages()
        {
            return Ok(await _languageManager.GetLanguages());
        }

        [HttpGet]
        [Route("territory")]
        public async Task<IActionResult> GetTerritories()
        {
            return Ok(await _languageManager.GetTerritories());
        }

        [HttpGet]
        [Route("levels")]
        public async Task<IActionResult> GetCourseLevels()
        {
            return Ok(await _languageManager.GetCourseLevels());
        }

        [HttpGet]
        [Route("{teaching}/{learning}")]
        public async Task<IActionResult> GetCoursesByLanguageCode(string teaching, string learning)
        {
            return Ok(await _courseManager.GetCoursesByLanguageCodeAsync(teaching, learning));
        }
    }
}
