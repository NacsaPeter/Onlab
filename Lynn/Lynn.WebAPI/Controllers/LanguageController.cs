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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LanguageController : Controller
    {
        private readonly ILanguageManager _languageManager;

        public LanguageController(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
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
    }
}
