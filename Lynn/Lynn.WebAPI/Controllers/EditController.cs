using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lynn.BLL;
using Lynn.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EditController : Controller
    {
        private readonly EditManager _editManager;

        public EditController(EditManager editManager)
        {
            _editManager = editManager;
        }

        [HttpPost("course")]
        public async Task<Course> CreateCourseAsync([FromBody]Course course)
        {
            return await _editManager.CreateCourseAsync(course);
        }

        [HttpPost("test")]
        public async Task<Test> CreateTestAsync([FromBody]Test test)
        {
            throw new NotImplementedException();
        }

        [HttpPut("course")]
        public async Task<Course> EditCourseAsync([FromBody]Course course)
        {
            throw new NotImplementedException();
        }

        [HttpPut("test")]
        public async Task<Test> EditTestAsync([FromBody]Test test)
        {
            throw new NotImplementedException();
        }
    }
}