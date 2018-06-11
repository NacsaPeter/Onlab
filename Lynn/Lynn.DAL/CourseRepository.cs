using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lynn.DTO;

namespace Lynn.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LynnDb _context;

        public CourseRepository(LynnDb context)
        {
            _context = context;
        }

        public ICollection<DbTest> GetTestsByCourseId(int id)
        {
            return _context.Tests
                .Where(t => t.CourseID == id)
                .ToList();
        }

        public DbCategory GetCategoryByTestId(int testId)
        {
            return _context.Tests
                .Where(t => t.ID == testId)
                .Select(t => t.Category)
                .SingleOrDefault();
        }

        public ICollection<DbVocabularyExercise> GetVocabularyExercisesByTestId(int id)
        {
            return _context.VocabularyExercises
                .Where(t => t.TestID == id)
                .ToList();
        }

        public Dictionary<string, string> GetLanguageCodeDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            var results = _context.Languages
                .Select(t => new { Key = t.Code, Value = t.Name })
                .ToList();
            foreach (var item in results)
            {
                dictionary.Add(item.Key, item.Value);
            }
            return dictionary;
        }

        public Dictionary<string, string> GetTerritoryCodeDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            var results = _context.Territories
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
