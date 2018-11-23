using AutoMapper;
using Lynn.BLL.Interfaces;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Managers
{
    public class TestManager: ITestManager
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestManager(
            ICourseRepository courseRepository,
            ITestRepository testRepository,
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Test>> GetTestsAsync(int courseId)
        {
            var tests = _mapper.Map<ICollection<Test>>(await _testRepository.GetTestsByCourseIdAsync(courseId));
            foreach (var test in tests)
            {
                test.CategoryName = (await _testRepository.GetCategoryByTestIdAsync(test.ID)).Name;
            }
            return tests;
        }
        
        public async Task<TestTrying> GetTestTryingAsync(int userId, int testId)
        {
            var dbTestUser = await _testRepository.GetTestUserAsync(userId, testId);
            var trying = _mapper.Map<TestTrying>(dbTestUser);
            trying.LastResult = _mapper.Map<TestResultDto>(dbTestUser.LastResult);
            trying.BestResult = _mapper.Map<TestResultDto>(dbTestUser.BestResult);
            return trying;
        }

        public async Task<User> AddTestResult(TestResultDto testResult, int userId, int testId)
        {
            var dbTestResult = _mapper.Map<DbTestResult>(testResult);
            return _mapper.Map<User>(await _testRepository.AddTestResultAsync(dbTestResult, userId, testId));
        }
    }
}
