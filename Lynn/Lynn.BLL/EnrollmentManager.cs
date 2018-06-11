using AutoMapper;
using Lynn.BLL.Services;
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

        public Enrollment EnrollCourse(Enrollment enrollment)
        {
            DbEnrollment dbEnrollment = _mapper.Map<DbEnrollment>(enrollment);
            return _mapper.Map<Enrollment>(_repo.EnrollCourse(dbEnrollment));
        }

        public async Task<ICollection<Course>> GetCoursesByName(string coursename)
        {
            var courses = _mapper.Map<ICollection<Course>>(_repo.GetCoursesByName(coursename));
            courses = await SetLanguageNames(courses);
            return SetCoursesEditorAndLevel(courses);
        }

        private async Task<ICollection<Course>> SetLanguageNames(ICollection<Course> courses)
        {
            var service = new CountriesService();
            foreach (var course in courses)
            {
                course.KnownLanguageName = (await service.GetLanguageByLanguageCode(course.KnownLanguage)).Name;
                course.LearningLanguageName = (await service.GetLanguageByLanguageCode(course.LearningLanguage)).Name;
            }
            return courses;
        }

        private ICollection<Course> SetCoursesEditorAndLevel(ICollection<Course> courses)
        {
            foreach (var course in courses)
            {
                course.Editor = _repo.GetEditorByCourseId(course.ID).Username;
                course.Level = _repo.GetCourseLevelByCourseId(course.ID).LevelCode;
            }
            return courses;
        }

        public Enrollment GetEnrollmentById(int enrollmentId)
        {
            return _mapper.Map<Enrollment>(_repo.GetEnrollmentById(enrollmentId));
        }

        public async Task<ICollection<Course>> GetEnrolledCourses(int userId)
        {
            var user = _repo.GetUserByID(userId);
            var courses = _mapper.Map<ICollection<Course>>(_repo.GetEnrolledCourses(user));
            courses = await SetLanguageNames(courses);
            return SetCoursesEditorAndLevel(courses);
        }
    }
}
