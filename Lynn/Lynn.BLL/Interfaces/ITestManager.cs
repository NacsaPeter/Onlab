using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Interfaces
{
    public interface ITestManager
    {
        Task<ICollection<Test>> GetTestsAsync(int courseId);
        Task<TestTrying> GetTestTryingAsync(int userId, int testId);
        Task<User> AddTestResult(TestResultDto testResult, int userId, int testId);
        Task<ICollection<string>> GetCategoriesAsync();
        Task<Test> CreateTestAsync(Test test);
        Task<Test> EditTestAsync(Test test);
        Task<bool> DeleteTestAsync(int id);
    }
}
