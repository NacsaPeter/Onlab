using Lynn.DTO;
using System;
using System.Collections.Generic;

namespace Lynn.DAL
{
    public interface IEnrollmentRepository
    {
        ICollection<DbCourse> GetEnrolledCourses(DbUser user);
        DbEnrollment EnrollCourse(DbEnrollment enrollment);
        DbUser GetUserByID(int id);
        ICollection<DbCourse> GetCoursesByName(string coursename);
        DbEnrollment GetEnrollmentById(int enrollmentId);
        DbUser GetEditorByCourseId(int courseId);
        DbCourseLevel GetCourseLevelByCourseId(int courseId);
    }
}
