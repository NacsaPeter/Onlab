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

        public TestsManager(ICourseRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Test> GetTests(int id)
        {
            return _repo.GetTestsByCourseId(id);
        }
    }
}
