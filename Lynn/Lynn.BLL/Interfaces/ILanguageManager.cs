using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Interfaces
{
    public interface ILanguageManager
    {
        Task<ICollection<Language>> GetLanguages();
        Task<ICollection<Territory>> GetTerritories();
        Task<ICollection<CourseLevelDto>> GetCourseLevels();
    }
}
