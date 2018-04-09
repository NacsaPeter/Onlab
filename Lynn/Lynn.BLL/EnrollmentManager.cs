using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;

namespace Lynn.BLL
{
    public class EnrollmentManager
    {
        private readonly IEnrollmentRepository repo;

        public EnrollmentManager(IEnrollmentRepository repo)
        {
            this.repo = repo;
        }

        public EnrollmentManager() : this(new EnrollmentRepository()) {}

        public int EnrollCourse(Enrollment enrollment)
        {
            return repo.EnrollCourse(enrollment);
        }

        public IEnumerable<Course> GetEnrolledCourses(int userId)
        {
            var user = repo.GetUserByID(userId);
            return repo.GetEnrolledCourses(user);
        }

        public int GetNumberOfEnrollments(int userId)
        {
            return repo.GetNumberOfEnrollments(userId);
        }

        public IEnumerable<Course> GetCoursesByName(string coursename)
        {
            return repo.GetCoursesByName(coursename);
        }
    }
}
