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
    }
}
