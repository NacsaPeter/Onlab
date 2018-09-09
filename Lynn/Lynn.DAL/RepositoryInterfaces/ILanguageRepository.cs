using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL
{
    public interface ILanguageRepository
    {
        Task<ICollection<DbLanguage>> GetLanguagesAsync();
    }
}
