using Lynn.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<ICollection<DbCourse>> GetMyCoursesAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByIdAsync(int id);
        Task<ApplicationUser> GetUserByNameAsync(string username);
    }
}
