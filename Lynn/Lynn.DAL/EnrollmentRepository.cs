using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lynn.DTO;
using AutoMapper;

namespace Lynn.DAL
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly LynnDb _context;

        public EnrollmentRepository(LynnDb context)
        {
            _context = context;
        }

        public IEnumerable<DbCourse> GetEnrolledCourses(DbUser user)
        {
            return _context.Enrollments
                .Join(_context.Courses, e => e.CourseID, c => c.ID, (e, c) => new { e, c })
                .Where(t => t.e.UserID == user.ID)
                .Select(t => t.e.Course);
        }

        public DbUser GetUserByID(int id)
        {
            return _context.Users
                    .Where(t => t.ID == id)
                    .SingleOrDefault();
        }

        // Todo: refactor
        public DbEnrollment EnrollCourse(DbEnrollment enrollment)
        {
            DbEnrollment existingEnrollment = _context.Enrollments
                .Where(e => e.CourseID == enrollment.CourseID && e.UserID == enrollment.UserID)
                .SingleOrDefault();

            // Todo: throw exception
            if (existingEnrollment != null)
            {
                return null;
            }

            var result = _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return result.Entity;
        }

        public IEnumerable<DbCourse> GetCoursesByName(string coursename)
        {
            return _context.Courses
                .Where(t => t.CourseName.Contains(coursename));
        }

        public DbEnrollment GetEnrollmentById(int enrollmentId)
        {
            return _context.Enrollments
                .Where(t => t.ID == enrollmentId)
                .SingleOrDefault();
        }

        public DbUser GetEditorByCourseId(int courseId)
        {
            return _context.Courses
                .Where(c => c.ID == courseId)
                .Select(c => c.User)
                .SingleOrDefault();
        }

        public DbCourseLevel GetCourseLevelByCourseId(int courseId)
        {
            return _context.Courses
                .Where(c => c.ID == courseId)
                .Select(c => c.Level)
                .SingleOrDefault();
        }
    }
}
