using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface ILanguageRepository
    {
        Task<ICollection<DbLanguage>> GetLanguagesAsync();
        Task<DbLanguage> GetLanguageByCodeAsync(string code);

        Task<ICollection<DbTerritory>> GetTerritoriesAsync();
        Task<DbTerritory> GetTerritoryByCodeAsync(string code);

        Task<ICollection<DbCourseLevel>> GetCourseLevelsAsync();
        Task<DbCourseLevel> GetCourseLevelByCourseIdAsync(int courseId);
    }
}
