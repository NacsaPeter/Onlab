using Lynn.BLL;
using Lynn.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ExercisesController : Controller
    {
        private readonly ExercisesManager _manager;

        public ExercisesController()
        {
            _manager = new ExercisesManager();
        }

        [HttpGet("{id}", Name = "GetExercisesByTestId")]
        public IEnumerable<VocabularyExercise> GetExercisesByTestId(int id)
        {
            return _manager.GetVocabularyExercises(id);
        }
    }
}
