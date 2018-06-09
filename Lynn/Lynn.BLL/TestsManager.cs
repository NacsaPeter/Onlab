using AutoMapper;
using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<Test> GetTests(int courseId)
        {
            var tests = _mapper.Map<IEnumerable<Test>>(_repo.GetTestsByCourseId(courseId));
            foreach (var test in tests)
            {
                test.CategoryName = _repo.GetCategoryByTestId(test.ID).Name;
            }
            return tests;
        }
    }
}
