using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL
{
    public interface ICourseRepository
    {
        IEnumerable<Test> GetTestsByCourseId(int id);
        IEnumerable<VocabularyExercise> GetVocabularyExercisesByTestId(int id);
    }
}
