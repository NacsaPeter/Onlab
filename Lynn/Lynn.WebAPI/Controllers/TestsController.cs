using Lynn.BLL;
using Lynn.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TestsController : Controller
    {
        private readonly TestsManager _manager;

        public TestsController(TestsManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id}")]
        public IActionResult GetTestsByCourseId(int id)
        {
            return Ok(_manager.GetTests(id));
        }

        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetTestsByCourseIdV2(int id)
        {
            var tests = _manager.GetTests(id);
            return Ok(new { tests.Count, tests });
        }
    }
}
