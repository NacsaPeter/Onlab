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

        public LanguageController()
        {
            _manager = new LanguageManager();
        }

        [HttpGet]
        public Dictionary<string, string> GetLanguageCodeDictionary()
        {
            return _manager.GetLanguageCodeDictionary();
        }

        [HttpGet]
        [Route("territory")]
        public Dictionary<string, string> GetTerritoryCodeDictionary()
        {
            return _manager.GetTerritoryCodeDictionary();
        }
    }
}
