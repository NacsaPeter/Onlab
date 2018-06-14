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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LanguageController : Controller
    {
        private readonly LanguageManager _languageManager;
        private readonly EnrollmentManager _enrollmentManager;

        public LanguageController(LanguageManager languageManager, EnrollmentManager enrollmentManager)
        {
            _languageManager = languageManager;
            _enrollmentManager = enrollmentManager;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "GuruOnly")]
        [HttpGet]
        public IActionResult GetLanguages()
        {
            return Ok(_languageManager.GetLanguages());
        }

        [HttpGet]
        [Route("{known}/{learning}")]
        public async Task<IActionResult> GetCoursesByLanguageCode(string known, string learning)
        {
            return Ok(await _enrollmentManager.GetCoursesByLanguageCode(known, learning));
        }
    }
}
