using Lynn.DTO;
using System;
using System.Collections.Generic;

namespace Lynn.DAL
{
    public interface IEnrollmentRepository
    {
        IEnumerable<Course> GetEnrolledCourses(User user);
        int EnrollCourse(Enrollment enrollment);
        User GetUserByID(int id);
        int GetNumberOfEnrollments(int userId);
        Enrollment GetEnrollmentById(int enrollmentId);
        IEnumerable<Course> GetCoursesByName(string coursename);
    }
}
