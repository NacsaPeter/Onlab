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

        public async Task<ICollection<DbLanguage>> GetLanguagesAsync()
        {
            return await _context.Languages
                .ToListAsync();
        }
    }
}
