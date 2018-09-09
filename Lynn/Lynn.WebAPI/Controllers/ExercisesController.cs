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
    public class ExercisesController : Controller
    {
        private readonly ExercisesManager _manager;

        public ExercisesController(ExercisesManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercisesByTestId(int id)
        {
            return Ok(await _manager.GetVocabularyExercisesAsync(id));
        }
    }
}
