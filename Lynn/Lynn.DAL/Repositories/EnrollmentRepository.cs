using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lynn.DAL.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lynn.DAL
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly LynnDb _context;

        public EnrollmentRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<ICollection<DbCourse>> GetEnrolledCoursesAsync(ApplicationUser user)
        {
            return await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Course.Level)
                .Include(e => e.Course.Editor)
                .Include(e => e.User)
                .Where(e => e.User.UserName == user.UserName)
                .Select(e => e.Course)
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByIDAsync(int id)
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

        // Todo: refactor
        public async Task<DbEnrollment> EnrollCourseAsync(DbEnrollment enrollment)
        {
            DbEnrollment existingEnrollment = _context.Enrollments
                .Where(e => e.CourseId == enrollment.CourseId && e.UserId == enrollment.UserId)
                .SingleOrDefault();

            // Todo: throw exception
            if (existingEnrollment != null)
            {
                return null;
            }

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            DbEnrollment newEnrollment = await _context.Enrollments
                .Where(e => e.CourseId == enrollment.CourseId && e.UserId == enrollment.UserId)
                .SingleOrDefaultAsync();

            return newEnrollment;
        }

        public async Task<ICollection<DbCourse>> GetCoursesByNameAsync(string coursename)
        {
            return await _context.Courses
                .Include(c => c.Editor)
                .Include(c => c.Level)
                .Where(t => t.CourseName.Contains(coursename))
                .ToListAsync();
        }

        public async Task<DbEnrollment> GetEnrollmentByIdAsync(int enrollmentId)
        {
            return await _context.Enrollments
                .Where(t => t.Id == enrollmentId)
                .SingleOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetEditorByCourseIdAsync(int courseId)
        {
            return await _context.Courses
                .Where(c => c.Id == courseId)
                .Select(c => c.Editor)
                .SingleOrDefaultAsync();
        }

        public async Task<DbCourseLevel> GetCourseLevelByCourseIdAsync(int courseId)
        {
            return await _context.Courses
                .Where(c => c.Id == courseId)
                .Select(c => c.Level)
                .SingleOrDefaultAsync();
        }

        public async Task<ICollection<DbCourse>> GetCoursesByLanguageCodeAsync(string known, string learning)
        {
            if (known == "" && learning != "")
            {
                return await _context.Courses
                    .Include(c => c.Level)
                    .Include(c => c.Editor)
                    .Where(c => c.TeachingLanguage == known)
                    .ToListAsync();
            }
            else if (known != "" && learning == "")
            {
                return await _context.Courses
                    .Include(c => c.Level)
                    .Include(c => c.Editor)
                    .Where(c => c.LearningLanguage == learning)
                    .ToListAsync();
            }
            else
            {
                return await _context.Courses
                    .Include(c => c.Level)
                    .Include(c => c.Editor)
                    .Where(l => l.TeachingLanguage == known 
                        && l.LearningLanguage == learning)
                    .ToListAsync();
            }
        }
    }
}
