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
    public class ExerciseController : Controller
    {
        private readonly IExerciseManager _exerciseManager;

        public ExerciseController(IExerciseManager exerciseManager)
        {
            _exerciseManager = exerciseManager;
        }

        [HttpGet("vocabulary/test/{id}")]
        public async Task<IActionResult> GetVocabularyExercisesByTestId(int id)
        {
            return Ok(await _exerciseManager.GetVocabularyExercisesAsync(id));
        }

        [HttpGet("grammar/test/{id}")]
        public async Task<IActionResult> GetGrammarExercisesByTestId(int id)
        {
            return Ok(await _exerciseManager.GetGrammarExercisesAsync(id));
        }

        [HttpGet("rule/test/{id}")]
        public async Task<IActionResult> GetGrammarRulesByTestId(int id)
        {
            return Ok(await _exerciseManager.GetGrammarRulesAsync(id));
        }
    }
}
