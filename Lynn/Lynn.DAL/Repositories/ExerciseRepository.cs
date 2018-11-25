using Lynn.DAL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly LynnDb _context;

        public ExerciseRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<ICollection<DbGrammarExercise>> GetGrammarExercisesByTestIdAsync(int testId)
        {
            return await _context.GrammarExercises
                .Include(e => e.Test)
                .Where(t => t.TestId == testId)
                .ToListAsync();
        }

        public async Task<ICollection<DbRule>> GetGrammarRulesByTestIdAsync(int testId)
        {
            return await _context.GrammarExercises
                .Include(e => e.Rule)
                .Where(e => e.TestId == testId)
                .Select(e => e.Rule)
                .Distinct()
                .ToListAsync();
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
