using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynn.DAL.Identity;
using Lynn.DAL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Lynn.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LynnDb _context;

        public CourseRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<DbCourse> CreateCourseAsync(DbCourse course)
        {
            if (course == null || course.Id != 0)
            {
                return null;
            }

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<DbCourse> EditCourseAsync(DbCourse course)
        {
            var oldCourse = await _context.Courses
                .Where(c => c.Id == course.Id)
                .SingleOrDefaultAsync();

            if (oldCourse == null)
            {
                return null;
            }

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return course;
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

        public async Task<ICollection<DbCourse>> GetCoursesByNameAsync(string coursename)
        {
            return await _context.Courses
                .Include(c => c.Editor)
                .Include(c => c.Level)
                .Where(t => t.CourseName.Contains(coursename))
                .ToListAsync();
        }

        public async Task<ICollection<DbCourse>> GetEnrolledCoursesAsync(ApplicationUser user)
        {
            return await _context.Enrollments
                .Include(e => e.User)
                .Where(e => e.User.Id == user.Id)
                .Select(e => e.Course)
                .Include(c => c.Level)
                .Include(c => c.Editor)
                .ToListAsync();
        }

        public async Task<ICollection<DbCourse>> GetCoursesByEditorAsync(ApplicationUser user)
        {
            return await _context.Courses
                .Include(c => c.Editor)
                .Where(c => c.Editor == user)
                .ToListAsync();
        }

    }
}
