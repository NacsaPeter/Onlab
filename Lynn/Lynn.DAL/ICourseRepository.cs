using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL
{
    public interface ICourseRepository
    {
        ICollection<DbTest> GetTestsByCourseId(int id);
        ICollection<DbVocabularyExercise> GetVocabularyExercisesByTestId(int id);
        DbCategory GetCategoryByTestId(int testId);
        Dictionary<string, string> GetLanguageCodeDictionary();
        Dictionary<string, string> GetTerritoryCodeDictionary();
    }
}
