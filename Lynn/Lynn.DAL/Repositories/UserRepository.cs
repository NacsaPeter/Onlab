using Lynn.DAL.Identity;
using Lynn.DAL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LynnDb _context;

        public UserRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<ICollection<DbCourse>> GetMyCoursesAsync(ApplicationUser user)
        {
            return await _context.Courses
                .Include(c => c.Editor)
                .Where(c => c.Editor == user)
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(int id)
        {
            return await _context.Users
                    .Where(t => t.Id == id)
                    .SingleOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string username)
        {
            return await _context.Users
                    .Where(t => t.UserName == username)
                    .SingleOrDefaultAsync();
        }
    }
}
