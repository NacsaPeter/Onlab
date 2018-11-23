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
    public class TestsController : Controller
    {
        private readonly ITestManager _testManager;

        public TestsController(ITestManager testManager)
        {
            _testManager = testManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestsByCourseIdAsync(int id)
        {
            return Ok(await _testManager.GetTestsAsync(id));
        }

        [HttpGet("{userId}/{testId}")]
        public async Task<IActionResult> GetTestTryingAsync(int userId, int testId)
        {
            return Ok(await _testManager.GetTestTryingAsync(userId, testId));
        }

        [HttpPost("result/{userId}/{testId}")]
        public async Task<IActionResult> AddTestResult([FromBody]TestResultDto testResult, int userId, int testId)
        {
            var user = await _testManager.AddTestResult(testResult, userId, testId);
            return Ok(user.Points);
        }
    }
}
