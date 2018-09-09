using AutoMapper;
using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lynn.BLL
{
    public class EnrollmentManager
    {
        private readonly IEnrollmentRepository _repo;
        private readonly IMapper _mapper;

        public EnrollmentManager(IEnrollmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Enrollment> EnrollCourseAsync(Enrollment enrollment)
        {
            DbEnrollment dbEnrollment = _mapper.Map<DbEnrollment>(enrollment);
            return _mapper.Map<Enrollment>(await _repo.EnrollCourseAsync(dbEnrollment));
        }

        public async Task<ICollection<Course>> GetCoursesByNameAsync(string coursename)
        {
            var courses = _mapper.Map<ICollection<Course>>(await _repo.GetCoursesByNameAsync(coursename));
            //return await SetLanguageNamesAsync(courses);
            return courses;
        }

        //private async Task<ICollection<Course>> SetLanguageNamesAsync(ICollection<Course> courses)
        //{
        //    var service = new CountriesService();
        //    foreach (var course in courses)
        //    {
        //        course.KnownLanguageName = (await service.GetLanguageByLanguageCode(course.KnownLanguage)).Name;
        //        course.LearningLanguageName = (await service.GetLanguageByLanguageCode(course.LearningLanguage)).Name;
        //    }
        //    return courses;
        //}

        public async Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId)
        {
            return _mapper.Map<Enrollment>(await _repo.GetEnrollmentByIdAsync(enrollmentId));
        }

        public async Task<ICollection<Course>> GetEnrolledCoursesAsync(int userId)
        {
            var user = await _repo.GetUserByIDAsync(userId);
            var courses = _mapper.Map<ICollection<Course>>(await _repo.GetEnrolledCoursesAsync(user));
            //return await SetLanguageNamesAsync(courses);
            return courses;
        }

        public async Task<ICollection<Course>> GetCoursesByLanguageCodeAsync(string known, string learning)
        {
            var courses = _mapper.Map<ICollection<Course>>(await _repo.GetCoursesByLanguageCodeAsync(known, learning));
            //return await SetLanguageNamesAsync(courses);
            return courses;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return _mapper.Map<User>(await _repo.GetUserByNameAsync(username));
        }
    }
}
