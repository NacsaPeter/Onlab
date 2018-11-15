using Lynn.BLL;
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
        private readonly LanguageManager _languageManager;
        private readonly EnrollmentManager _enrollmentManager;

        public LanguageController(LanguageManager languageManager, EnrollmentManager enrollmentManager)
        {
            _languageManager = languageManager;
            _enrollmentManager = enrollmentManager;
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
        [Route("{known}/{learning}")]
        public async Task<IActionResult> GetCoursesByLanguageCode(string known, string learning)
        {
            return Ok(await _enrollmentManager.GetCoursesByLanguageCodeAsync(known, learning));
        }
    }
}
