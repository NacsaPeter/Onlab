using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynn.DAL.Identity;
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

        public async Task<ApplicationUser> AddTestResultAsync(DbTestResult testResult, int userId, int testId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .SingleOrDefaultAsync();

            var test = await _context.Tests
                .Include(t => t.Course)
                .ThenInclude(c => c.Editor)
                .Where(t => t.Id == testId)
                .SingleOrDefaultAsync();

            var tryings = await _context.TestTryings
                .Include(tt => tt.BestResult)
                .Include(tt => tt.LastResult)
                .Where(tt => tt.TestId == testId && tt.UserId == userId)
                .SingleOrDefaultAsync();

            var enrollment = await _context.Enrollments
                    .Where(e => e.CourseId == test.CourseId && e.UserId == userId)
                    .SingleOrDefaultAsync();

            #region Tryings

            tryings.Attempts++;
            tryings.LastResult = testResult;

            if (tryings.BestResult.RightAnswers < testResult.RightAnswers)
            {
                enrollment.Points -= tryings.BestResult.Points;
                enrollment.Points += testResult.Points;

                tryings.BestResult = testResult;
            }

            if (!tryings.IsCorrect && testResult.RightAnswers >= test.NumberOfQuestions * 0.85)
            {
                tryings.IsCorrect = true;

                var testUsers = await _context.TestTryings
                    .Where(tt => tt.UserId == userId && tt.Test.CourseId == test.CourseId)
                    .ToListAsync();

                bool newLevel = true;
                foreach (var testUser in testUsers)
                {
                    if (!testUser.IsCorrect)
                    {
                        newLevel = false;
                    }
                }
                if (newLevel)
                {
                    enrollment.Level++;
                }
            }

            #endregion

            #region User points

            if (test.Course.EditorId != userId)
            {
                float actualPoints = testResult.RightAnswers / (float)test.NumberOfQuestions * (float)test.MaxPoints;
                int globalPoints = (int)Math.Ceiling(actualPoints / tryings.Attempts);
                user.Points += globalPoints;
            }

            #endregion

            await _context.SaveChangesAsync();
            return user;
        }
    }
}
