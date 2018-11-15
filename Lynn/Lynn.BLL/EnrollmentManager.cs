using AutoMapper;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lynn.BLL
{
    public class EnrollmentManager
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public EnrollmentManager(
            IEnrollmentRepository enrollmentRepository,
            ILanguageRepository languageRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _languageRepository = languageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Enrollment> EnrollCourseAsync(Enrollment enrollment)
        {
            DbEnrollment dbEnrollment = _mapper.Map<DbEnrollment>(enrollment);

            return _mapper.Map<Enrollment>(
                    await _enrollmentRepository.EnrollCourseAsync(dbEnrollment)
                );
        }

        public async Task<ICollection<Course>> GetCoursesByNameAsync(string coursename)
        {
            var dbCourses = await _enrollmentRepository
                .GetCoursesByNameAsync(coursename);

            var courseMapper = new CourseMapper(_languageRepository, _mapper);
            return await courseMapper.MapDbCourseCollection(dbCourses);
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId)
        {
            return _mapper.Map<Enrollment>(
                    await _enrollmentRepository.GetEnrollmentByIdAsync(enrollmentId)
                );
        }

        public async Task<Enrollment> GetEnrollmentAsync(int userId, int couseId)
        {
            return _mapper.Map<Enrollment>(
                    await _enrollmentRepository.GetEnrollmentAsync(userId, couseId)
                );
        }

        public async Task<ICollection<Course>> GetEnrolledCoursesAsync(int userId)
        {
            var user = await _userRepository
                .GetUserByIdAsync(userId);

            var dbCourses = await _enrollmentRepository
                .GetEnrolledCoursesAsync(user);

            var courseMapper = new CourseMapper(_languageRepository, _mapper);
            return await courseMapper.MapDbCourseCollection(dbCourses);
        }

        public async Task<ICollection<Course>> GetCoursesByLanguageCodeAsync(string known, string learning)
        {
            var dbCourses = await _enrollmentRepository
                .GetCoursesByLanguageCodeAsync(known, learning);

            var courseMapper = new CourseMapper(_languageRepository, _mapper);
            return await courseMapper.MapDbCourseCollection(dbCourses);
        }
    }
}
