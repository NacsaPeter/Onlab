using Lynn.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface IEnrollmentRepository
    {
        Task<DbEnrollment> EnrollCourseAsync(DbEnrollment enrollment);
        Task<DbEnrollment> GetEnrollmentByIdAsync(int enrollmentId);
        Task<DbEnrollment> GetEnrollmentAsync(int userId, int courseId);
    }
}
