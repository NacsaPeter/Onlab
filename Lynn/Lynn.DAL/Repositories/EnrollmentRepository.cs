using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lynn.DAL.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lynn.DAL.RepositoryInterfaces;

namespace Lynn.DAL
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly LynnDb _context;

        public EnrollmentRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<DbEnrollment> EnrollCourseAsync(DbEnrollment enrollment)
        {
            DbEnrollment existingEnrollment = _context.Enrollments
                .Where(e => e.CourseId == enrollment.CourseId && e.UserId == enrollment.UserId)
                .SingleOrDefault();

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

        public async Task<DbEnrollment> GetEnrollmentByIdAsync(int enrollmentId)
        {
            return await _context.Enrollments
                .Where(t => t.Id == enrollmentId)
                .SingleOrDefaultAsync();
        }

        public async Task<DbEnrollment> GetEnrollmentAsync(int userId, int courseId)
        {
            return await _context.Enrollments
                .Where(e => e.UserId == userId && e.CourseId == courseId)
                .SingleOrDefaultAsync();
        }
    }
}
