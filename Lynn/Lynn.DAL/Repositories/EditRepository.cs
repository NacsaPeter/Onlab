using Lynn.DAL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.Repositories
{
    public class EditRepository : IEditRepository
    {
        private readonly LynnDb _context;

        public EditRepository(LynnDb context)
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

        public async Task<DbTest> CreateTestAsync(DbTest test)
        {
            if (test == null || test.Id != 0)
            {
                return null;
            }

            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            return test;
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

        public async Task<DbTest> EditTestAsync(DbTest test)
        {
            var oldTest = await _context.Tests
                .Where(c => c.Id == test.Id)
                .SingleOrDefaultAsync();

            if (oldTest == null)
            {
                return null;
            }

            _context.Tests.Update(test);
            await _context.SaveChangesAsync();

            return test;
        }
    }
}
