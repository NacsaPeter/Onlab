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

        [HttpPost("grammar")]
        public async Task<IActionResult> CreateGrammarExerciseAsync([FromBody]GrammarExercise grammarExercise)
        {
            return Ok(await _exerciseManager.CreateGrammarExerciseAsync(grammarExercise));
        }

        [HttpPut("grammar")]
        public async Task<IActionResult> EditGrammarExerciseAsync([FromBody]GrammarExercise grammarExercise)
        {
            return Ok(await _exerciseManager.EditGrammarExerciseAsync(grammarExercise));
        }

        [HttpDelete("grammar/{id:int}")]
        public async Task<IActionResult> DeleteGrammarExerciseAsync(int id)
        {
            bool success = await _exerciseManager.DeleteGrammarExerciseAsync(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("vocabulary")]
        public async Task<IActionResult> CreateVocabularyExerciseAsync([FromBody]VocabularyExercise vocabularyExercise)
        {
            return Ok(await _exerciseManager.CreateVocabularyExerciseAsync(vocabularyExercise));
        }

        [HttpPut("vocabulary")]
        public async Task<IActionResult> EditVocabularyExerciseAsync([FromBody]VocabularyExercise vocabularyExercise)
        {
            return Ok(await _exerciseManager.EditVocabularyExerciseAsync(vocabularyExercise));
        }

        [HttpDelete("vocabulary/{id:int}")]
        public async Task<IActionResult> DeleteVocabularyExerciseAsync(int id)
        {
            bool success = await _exerciseManager.DeleteVocabularyExerciseAsync(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("rule")]
        public async Task<IActionResult> CreateRuleAsync([FromBody]RuleDto rule)
        {
            return Ok(await _exerciseManager.CreateRuleAsync(rule));

        }

        [HttpPut("rule")]
        public async Task<IActionResult> EditRuleAsync([FromBody]RuleDto rule)
        {
            return Ok(await _exerciseManager.EditRuleAsync(rule));

        }

        [HttpDelete("rule/{id:int}")]
        public async Task<IActionResult> DeleteRuleAsync(int id)
        {
            bool success = await _exerciseManager.DeleteRuleAsync(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
