using Lynn.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface ITestRepository
    {
        Task<ICollection<DbTest>> GetTestsByCourseIdAsync(int id);
        Task<DbTest> CreateTestAsync(DbTest test);
        Task<DbTest> EditTestAsync(DbTest test);
        Task<bool> DeleteTestAsync(int id);

        Task<DbCategory> GetCategoryByTestIdAsync(int testId);
        Task<ICollection<DbCategory>> GetCategories();

        Task<ApplicationUser> AddTestResultAsync(DbTestResult testResult, int userId, int testId);
        Task<DbTestUser> GetTestUserAsync(int userId, int testId);
    }
}
