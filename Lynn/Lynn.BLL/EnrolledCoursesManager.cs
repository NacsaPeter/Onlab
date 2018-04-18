using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.BLL
{
    public class EnrolledCoursesManager
    {
        private readonly IEnrollmentRepository _repo;

        public EnrolledCoursesManager(IEnrollmentRepository repo)
        {
            _repo = repo;
        }

        public EnrolledCoursesManager() : this(new EnrollmentRepository()) { }

        public IEnumerable<Course> GetEnrolledCourses(int userId)
        {
            var user = _repo.GetUserByID(userId);
            return _repo.GetEnrolledCourses(user);
        }
    }
}
