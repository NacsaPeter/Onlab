using Lynn.DAL.Identity;
using Lynn.DAL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.Repositories
{
    public class TestRepository: ITestRepository
    {
        private readonly LynnDb _context;

        public TestRepository(LynnDb context)
        {
            _context = context;
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

        public async Task<DbTest> CreateTestAsync(DbTest test)
        {
            if (test == null || test.Id != 0)
            {
                return null;
            }

            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            return test;
        }

        public async Task<bool> DeleteTestAsync(int id)
        {
            var test = await _context.Tests
                .Include(t => t.Category)
                .Where(t => t.Id == id)
                .SingleOrDefaultAsync();

            if (test == null)
            {
                return false;
            }

            try
            {
                if (test.Category.Name == "Nyelvtan")
                {
                    var exercises = await _context.GrammarExercises
                        .Where(e => e.TestId == test.Id)
                        .ToListAsync();

                    var rules = await _context.Rules
                        .Where(r => r.TestId == test.Id)
                        .ToListAsync();

                    _context.Rules.RemoveRange(rules);
                    _context.Rules.RemoveRange(rules);
                }

                _context.Tests.Remove(test);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<DbTest> EditTestAsync(DbTest test)
        {
            var oldTest = await _context.Tests
                .Where(c => c.Id == test.Id)
                .SingleOrDefaultAsync();

            if (oldTest == null)
            {
                return null;
            }

            if (oldTest.Category != test.Category)
            {
                oldTest.Category = test.Category;
            }

            if (oldTest.Level != test.Level)
            {
                oldTest.Level = test.Level;
            }

            if (oldTest.MaxPoints != test.MaxPoints)
            {
                oldTest.MaxPoints = test.MaxPoints;
            }

            try
            {
                _context.Tests.Update(oldTest);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return test;
        }

        public async Task<ICollection<DbCategory>> GetCategories()
        {
            return await _context.Catergories
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

        public async Task<ICollection<DbTest>> GetTestsByCourseIdAsync(int id)
        {
            return await _context.Tests
                .Include(t => t.Category)
                .Include(t => t.Course)
                .Where(t => t.CourseId == id)
                .OrderBy(t => t.Level)
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
