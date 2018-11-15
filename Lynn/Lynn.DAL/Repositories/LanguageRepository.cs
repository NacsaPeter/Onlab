using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly LynnDb _context;

        public LanguageRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<ICollection<DbCourseLevel>> GetCourseLevelsAsync()
        {
            return await _context.CourseLevels
                .ToListAsync();
        }

        public async Task<DbLanguage> GetLanguageByCodeAsync(string code)
        {
            return await _context.Languages
                .Where(l => l.Code == code)
                .SingleOrDefaultAsync();
        }

        public async Task<ICollection<DbLanguage>> GetLanguagesAsync()
        {
            return await _context.Languages
                .ToListAsync();
        }

        public async Task<ICollection<DbTerritory>> GetTerritoriesAsync()
        {
            return await _context.Territories
                .ToListAsync();
        }

        public async Task<DbTerritory> GetTerritoryByCodeAsync(string code)
        {
            return await _context.Territories
                .Where(t => t.Code == code)
                .SingleOrDefaultAsync();
        }
    }
}
