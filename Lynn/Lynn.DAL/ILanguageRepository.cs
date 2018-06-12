using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL
{
    public interface ILanguageRepository
    {
        ICollection<DbLanguage> GetLanguages();
    }
}
