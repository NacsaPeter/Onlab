using Lynn.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface ICourseRepository
    {
        Task<ICollection<DbCourse>> GetCoursesByNameAsync(string coursename);
        Task<ICollection<DbCourse>> GetCoursesByLanguageCodeAsync(string teaching, string learning);
        Task<ICollection<DbCourse>> GetEnrolledCoursesAsync(ApplicationUser user);
        Task<ICollection<DbCourse>> GetCoursesByEditorAsync(ApplicationUser user);
        Task<DbCourse> CreateCourseAsync(DbCourse course);
        Task<DbCourse> EditCourseAsync(DbCourse course);
    }
}
