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
    }
}
