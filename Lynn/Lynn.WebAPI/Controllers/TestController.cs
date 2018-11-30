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
    public class TestController : Controller
    {
        private readonly ITestManager _testManager;

        public TestController(ITestManager testManager)
        {
            _testManager = testManager;
        }

        [HttpGet("course/{id}")]
        public async Task<IActionResult> GetTestsByCourseIdAsync(int id)
        {
            return Ok(await _testManager.GetTestsAsync(id));
        }

        [HttpGet("trying/{userId}/{testId}")]
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

        [HttpPost]
        public async Task<IActionResult> CreateTestAsync([FromBody]Test test)
        {
            return Ok(await _testManager.CreateTestAsync(test));
        }

        [HttpPut]
        public async Task<IActionResult> EditTestAsync([FromBody]Test test)
        {
            return Ok(await _testManager.EditTestAsync(test));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTestAsync(int id)
        {
            bool success = await _testManager.DeleteTestAsync(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return Ok(await _testManager.GetCategoriesAsync());
        }
    }
}
