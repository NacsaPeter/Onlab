using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Interfaces
{
    public interface IEnrollmentManager
    {
        Task<Enrollment> EnrollCourseAsync(Enrollment enrollment);
        Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId);
        Task<Enrollment> GetEnrollmentAsync(int userId, int couseId);
    }
}
