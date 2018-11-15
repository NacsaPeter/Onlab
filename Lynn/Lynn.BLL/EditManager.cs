using AutoMapper;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL
{
    public class EditManager
    {
        private readonly IEditRepository _editRepository;
        private readonly IMapper _mapper;

        public async Task<Course> CreateCourseAsync(Course course)
        {
            var dbCourse = _mapper.Map<DbCourse>(course);
            var createdCourse = await _editRepository.CreateCourseAsync(dbCourse);
            return _mapper.Map<Course>(createdCourse);
        }
    }
}
