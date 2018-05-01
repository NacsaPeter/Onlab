using Lynn.BLL;
using Lynn.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TestsController : Controller
    {
        private readonly TestsManager _manager;

        public TestsController()
        {
            _manager = new TestsManager();
        }

        [HttpGet("{id}", Name = "GetTestsByCourseId")]
        public IEnumerable<Test> GetTestsByCourseId(int id)
        {
            return _manager.GetTests(id);
        }
    }
}
