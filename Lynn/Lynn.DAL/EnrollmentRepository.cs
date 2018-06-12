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

        public ICollection<DbCourse> GetEnrolledCourses(DbUser user)
        {
            return _context.Enrollments
                .Join(_context.Courses, e => e.CourseID, c => c.ID, (e, c) => new { e, c })
                .Where(t => t.e.UserID == user.ID)
                .Select(t => t.e.Course)
                .ToList();
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

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            DbEnrollment newEnrollment = _context.Enrollments
                .Where(e => e.CourseID == enrollment.CourseID && e.UserID == enrollment.UserID)
                .SingleOrDefault();

            return newEnrollment;
        }

        public ICollection<DbCourse> GetCoursesByName(string coursename)
        {
            return _context.Courses
                .Where(t => t.CourseName.Contains(coursename))
                .ToList();
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

        public ICollection<DbCourse> GetCoursesByLanguageCode(string known, string learning)
        {
            if (known == "" && learning != "")
            {
                return _context.Languages
                    .Where(l => l.Code == learning)
                    .SingleOrDefault()
                    .CoursesAsLearning;
            }
            else if (known != "" && learning == "")
            {
                return _context.Languages
                    .Where(l => l.Code == known)
                    .SingleOrDefault()
                    .CoursesAsKnown;
            }
            else
            {
                return _context.Courses
                    .Where(l => l.KnownLanguage == known && l.LearningLanguage == learning)
                    .ToList();
            }
        }
    }
}
