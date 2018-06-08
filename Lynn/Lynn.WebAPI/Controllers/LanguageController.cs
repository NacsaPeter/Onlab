using Lynn.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LanguageController : Controller
    {
        private readonly LanguageManager _manager;

        public LanguageController(LanguageManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetLanguageCodeDictionary()
        {
            return Ok(_manager.GetLanguageCodeDictionary());
        }

        [HttpGet]
        [Route("territory")]
        public IActionResult GetTerritoryCodeDictionary()
        {
            return Ok(_manager.GetTerritoryCodeDictionary());
        }
    }
}
