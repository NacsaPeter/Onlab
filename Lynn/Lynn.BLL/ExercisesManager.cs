using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.BLL
{
    public class ExercisesManager
    {
        private readonly ICourseRepository _repo;

        public ExercisesManager(ICourseRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<VocabularyExercise> GetVocabularyExercises(int testId)
        {
            return _repo.GetVocabularyExercisesByTestId(testId);
        }
    }
}
