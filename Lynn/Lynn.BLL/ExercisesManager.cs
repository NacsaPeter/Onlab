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

        public ExercisesManager() : this(new CourseRepository()) { }

        public IEnumerable<VocabularyExercise> GetVocabularyExercises(int id)
        {
            return _repo.GetVocabularyExercisesByTestId(id);
        }
    }
}
