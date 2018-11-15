using AutoMapper;
using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL
{
    public class TestsManager
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;

        public TestsManager(ICourseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ICollection<Test>> GetTestsAsync(int courseId)
        {
            var tests = _mapper.Map<ICollection<Test>>(await _repo.GetTestsByCourseIdAsync(courseId));
            foreach (var test in tests)
            {
                test.CategoryName = (await _repo.GetCategoryByTestIdAsync(test.ID)).Name;
            }
            return tests;
        }
        
        public async Task<TestTrying> GetTestTryingAsync(int userId, int testId)
        {
            var dbTestUser = await _repo.GetTestUserAsync(userId, testId);
            var trying = _mapper.Map<TestTrying>(dbTestUser);
            trying.LastResult = _mapper.Map<TestResultDto>(dbTestUser.LastResult);
            trying.BestResult = _mapper.Map<TestResultDto>(dbTestUser.BestResult);
            return trying;
        }

        public async Task<User> AddTestResult(TestResultDto testResult, int userId, int testId)
        {
            var dbTestResult = _mapper.Map<DbTestResult>(testResult);
            return _mapper.Map<User>(await _repo.AddTestResultAsync(dbTestResult, userId, testId));
        }
    }
}
