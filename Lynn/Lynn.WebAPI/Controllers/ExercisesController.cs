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
    public class ExercisesController : Controller
    {
        private readonly ExercisesManager _manager;

        public ExercisesController(ExercisesManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id}")]
        public IActionResult GetExercisesByTestId(int id)
        {
            return Ok(_manager.GetVocabularyExercises(id));
        }

        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetExercisesByTestIdV2(int id)
        {
            var exercises = _manager.GetVocabularyExercises(id);
            return Ok(new { exercises.Count, exercises});
        }
    }
}
