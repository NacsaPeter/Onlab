using Lynn.DTO;
using System;
using System.Collections.Generic;

namespace Lynn.DAL
{
    public interface IEnrollmentRepository
    {
        IEnumerable<Course> GetEnrolledCourses(User user);
        Enrollment EnrollCourse(Enrollment enrollment);
        User GetUserByID(int id);
        IEnumerable<Course> GetCoursesByName(string coursename);
        Enrollment GetEnrollmentById(int enrollmentId);
    }
}
