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
    public class ExercisesController : Controller
    {
        private readonly IExerciseManager _exerciseManager;

        public ExercisesController(IExerciseManager exerciseManager)
        {
            _exerciseManager = exerciseManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercisesByTestId(int id)
        {
            return Ok(await _exerciseManager.GetVocabularyExercisesAsync(id));
        }
    }
}
