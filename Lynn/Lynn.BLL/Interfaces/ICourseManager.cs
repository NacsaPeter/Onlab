using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Interfaces
{
    public interface ICourseManager
    {
        Task<Course> CreateCourseAsync(Course course);
        Task<ICollection<Course>> GetCoursesByNameAsync(string coursename);
        Task<ICollection<Course>> GetEnrolledCoursesAsync(int userId);
        Task<ICollection<Course>> GetCoursesByLanguageCodeAsync(string known, string learning);
        Task<ICollection<Course>> GetCoursesByEditorNameAsync(string username);
    }
}
