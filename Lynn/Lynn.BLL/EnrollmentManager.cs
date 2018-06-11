using AutoMapper;
using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;

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

        public ICollection<Course> GetCoursesByName(string coursename)
        {
            var courses = _mapper.Map<ICollection<Course>>(_repo.GetCoursesByName(coursename));
            return SetCoursesEditorAndLevel(courses);
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

        public ICollection<Course> GetEnrolledCourses(int userId)
        {
            var user = _repo.GetUserByID(userId);
            var courses = _mapper.Map<ICollection<Course>>(_repo.GetEnrolledCourses(user));
            return SetCoursesEditorAndLevel(courses);
        }
    }
}
