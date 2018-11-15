using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lynn.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LynnDb _context;

        public CourseRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<ICollection<DbTest>> GetTestsByCourseIdAsync(int id)
        {
            return await _context.Tests
                .Include(t => t.Category)
                .Include(t => t.Course)
                .Where(t => t.CourseId == id)
                .ToListAsync();
        }

        public async Task<DbCategory> GetCategoryByTestIdAsync(int testId)
        {
            return await _context.Tests
                .Include(t => t.Category)
                .Where(t => t.Id == testId)
                .Select(t => t.Category)
                .SingleOrDefaultAsync();
        }

        public async Task<ICollection<DbVocabularyExercise>> GetVocabularyExercisesByTestIdAsync(int id)
        {
            return await _context.VocabularyExercises
                .Include(e => e.Test)
                .Where(t => t.TestId == id)
                .ToListAsync();
        }

        public async Task<DbTestUser> GetTestUserAsync(int userId, int testId)
        {
            var trying = await _context.TestTryings
                .Include(t => t.BestResult)
                .Include(t => t.LastResult)
                .Where(t => t.UserId == userId && t.TestId == testId)
                .SingleOrDefaultAsync();

            if (trying == null)
            {
                trying = new DbTestUser
                {
                    Attempts = 0,
                    BestResult = new DbTestResult
                    {
                        RightAnswers = 0,
                        WrongAnswers = 0,
                        Points = 0
                    },
                    IsCorrect = false,
                    LastResult = new DbTestResult
                    {
                        RightAnswers = 0,
                        WrongAnswers = 0,
                        Points = 0
                    },
                    TestId = testId,
                    UserId = userId
                };
                _context.Add(trying);
                await _context.SaveChangesAsync();
            }

            return trying;
        }
    }
}
