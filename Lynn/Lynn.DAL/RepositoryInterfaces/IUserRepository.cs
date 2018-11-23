using Lynn.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(int id);
        Task<ApplicationUser> GetUserByNameAsync(string username);
        Task<ApplicationUser> GetEditorByCourseIdAsync(int courseId);
    }
}
