using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lynn.DTO;

namespace Lynn.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private LynnDb getDB()
        {
            return new LynnDb();
        }

        public IEnumerable<Test> GetTestsByCourseId(int id)
        {
            using (var db = getDB())
            {
                return db.Tests
                    .Where(t => t.CourseID == id)
                    .Select(t => new Test
                    {
                        ID = t.ID,
                        CategoryName = t.Category.Name,
                        CourseID = t.CourseID,
                        Level = t.Level,
                        MaxPoints = t.MaxPoints,
                        NumberOfQuestions = t.NumberOfQuestions
                    })
                    .ToList();
            }
        }

        public IEnumerable<VocabularyExercise> GetVocabularyExercisesByTestId(int id)
        {
            using (var db = getDB())
            {
                return db.VocabularyExercises
                    .Where(t => t.TestID == id)
                    .Select(t => new VocabularyExercise
                    {
                        ID = t.ID,
                        TestID = t.TestID,
                        Expression = t.Expression,
                        TranslatedExpression = t.TranslatedExpression,
                        WrongAnswer1 = t.WrongAnswer1,
                        WrongAnswer2 = t.WrongAnswer2,
                        WrongAnswer3 = t.WrongAnswer3,
                        TranslatedWrongAnswer1 = t.TranslatedWrongAnswer1,
                        TranslatedWrongAnswer2 = t.TranslatedWrongAnswer2,
                        TranslatedWrongAnswer3 = t.TranslatedWrongAnswer3,
                        Sentence = t.Sentence,
                        TranslatedSentence = t.TranslatedSentence,
                        Picture = t.Picture
                    })
                    .ToList();
            }
        }

        public Dictionary<string, string> GetLanguageCodeDictionary()
        {
            using (var db = getDB())
            {
                var dictionary = new Dictionary<string, string>();
                var results = db.Languages
                    .Select(t => new { Key = t.Code, Value = t.Name })
                    .ToList();
                foreach (var item in results)
                {
                    dictionary.Add(item.Key, item.Value);
                }
                return dictionary;
            }
        }

        public Dictionary<string, string> GetTerritoryCodeDictionary()
        {
            using (var db = getDB())
            {
                var dictionary = new Dictionary<string, string>();
                var results = db.Territories
                    .Select(t => new { Key = t.Code, Value = t.Name })
                    .ToList();
                foreach (var item in results)
                {
                    dictionary.Add(item.Key, item.Value);
                }
                return dictionary;
            }
        }
    }
}
