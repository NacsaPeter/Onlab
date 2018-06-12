using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lynn.DAL
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly LynnDb _context;

        public LanguageRepository(LynnDb context)
        {
            _context = context;
        }

        public ICollection<DbLanguage> GetLanguages()
        {
            return _context.Languages.ToList();
        }
    }
}
