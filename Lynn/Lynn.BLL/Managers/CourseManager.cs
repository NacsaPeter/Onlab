using AutoMapper;
using Lynn.BLL.Interfaces;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Managers
{
    public class CourseManager: ICourseManager
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CourseManager(
            ICourseRepository courseRepository,
            ILanguageRepository languageRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _languageRepository = languageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            var dbCourse = _mapper.Map<DbCourse>(course);
            var createdCourse = await _courseRepository.CreateCourseAsync(dbCourse);
            return _mapper.Map<Course>(createdCourse);
        }

        public async Task<ICollection<Course>> GetCoursesByLanguageCodeAsync(string known, string learning)
        {
            var dbCourses = await _courseRepository
                .GetCoursesByLanguageCodeAsync(known, learning);

            var courseMapper = new CourseMapper(_languageRepository, _mapper);
            return await courseMapper.MapDbCourseCollection(dbCourses);
        }

        public async Task<ICollection<Course>> GetCoursesByNameAsync(string coursename)
        {
            var dbCourses = await _courseRepository
                .GetCoursesByNameAsync(coursename);

            var courseMapper = new CourseMapper(_languageRepository, _mapper);
            return await courseMapper.MapDbCourseCollection(dbCourses);
        }

        public async Task<ICollection<Course>> GetEnrolledCoursesAsync(int userId)
        {
            var user = await _userRepository
                .GetUserByIdAsync(userId);

            var dbCourses = await _courseRepository
                .GetEnrolledCoursesAsync(user);

            var courseMapper = new CourseMapper(_languageRepository, _mapper);
            return await courseMapper.MapDbCourseCollection(dbCourses);
        }

        public async Task<ICollection<Course>> GetCoursesByEditorNameAsync(string username)
        {
            var editor = await _userRepository
                .GetUserByNameAsync(username);

            var dbCourses = await _courseRepository
                .GetCoursesByEditorAsync(editor);

            var courseMapper = new CourseMapper(_languageRepository, _mapper);
            return await courseMapper.MapDbCourseCollection(dbCourses);
        }
    }
}
