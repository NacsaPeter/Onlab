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
        public async Task<IActionResult> GetTestsByCourseIdAsync(int id)
        {
            return Ok(await _manager.GetTestsAsync(id));
        }

        [HttpGet("{userId}/{testId}")]
        public async Task<IActionResult> GetTestTryingAsync(int userId, int testId)
        {
            return Ok(await _manager.GetTestTryingAsync(userId, testId));
        }
    }
}
