using Lynn.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lynn.DAL
{
    public interface IEnrollmentRepository
    {
        Task<ICollection<DbCourse>> GetEnrolledCoursesAsync(ApplicationUser user);
        Task<DbEnrollment> EnrollCourseAsync(DbEnrollment enrollment);        
        Task<ICollection<DbCourse>> GetCoursesByNameAsync(string coursename);
        Task<DbEnrollment> GetEnrollmentByIdAsync(int enrollmentId);
        Task<DbEnrollment> GetEnrollmentAsync(int userId, int courseId);
        Task<ApplicationUser> GetEditorByCourseIdAsync(int courseId);
        Task<DbCourseLevel> GetCourseLevelByCourseIdAsync(int courseId);
        Task<ICollection<DbCourse>> GetCoursesByLanguageCodeAsync(string known, string learning);
    }
}
