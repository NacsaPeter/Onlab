using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lynn.DTO;

namespace Lynn.DAL
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private LynnDb getDB()
        {
            return new LynnDb();
        }

        public IEnumerable<Course> GetEnrolledCourses(User user)
        {
            using (var db = getDB())
            {
                return db.Enrollments
                    .Join(db.Courses, e => e.CourseID, c => c.ID, (e, c) => new { e, c })
                    .Where(t => t.e.UserID == user.ID)
                    .Select(t => new Course
                    {
                        CourseName = t.c.CourseName,
                        ID = t.c.ID,
                        KnownLanguage = t.c.KnownLanguage,
                        LearningLanguage = t.c.LearningLanguage,
                        KnownLanguageTerritory = t.c.KnownLanguageTerritory,
                        LearningLanguageTerritory = t.c.LearningLanguageTerritory,
                        Details = t.c.Details,
                        Editor = t.c.User.Username,
                        Level = t.c.Level.LevelCode
                    })
                    .ToList();
                
            }
        }

        public User GetUserByID(int id)
        {
            using (var db = getDB())
            {
                return db.Users
                        .Where(t => t.ID == id)
                        .Select(t => new User
                        {
                            ID = t.ID,
                            Email = t.Email,
                            PasswordHash = t.PasswordHash,
                            Points = t.Points,
                            Username = t.Username
                        })
                        .Single();
            }
        }

        public int EnrollCourse(Enrollment enrollment)
        {
            using (var db = getDB())
            {
                var dbEnrollment = new DbEnrollment
                {
                    CourseID = enrollment.CourseId,
                    UserID = enrollment.UserId,
                    Level = enrollment.Level,
                    Points = enrollment.Points
                };

                DbEnrollment existingEnrollment = db.Enrollments
                    .Where(e => e.CourseID == dbEnrollment.CourseID && e.UserID == dbEnrollment.UserID)
                    .SingleOrDefault();

                if (existingEnrollment != null)
                {
                    return -1;
                }

                var result = db.Enrollments.Add(dbEnrollment);
                db.SaveChanges();

                var enrollmentId = result.GetDatabaseValues().GetValue<int>("ID");
                return enrollmentId;
            }
        }

        public IEnumerable<Course> GetCoursesByName(string coursename)
        {
            return getDB().Courses
                .Where(t => t.CourseName.Contains(coursename))
                .Select(t => new Course
                {
                    CourseName = t.CourseName,
                    ID = t.ID,
                    KnownLanguage = t.KnownLanguage,
                    LearningLanguage = t.LearningLanguage,
                    KnownLanguageTerritory = t.KnownLanguageTerritory,
                    LearningLanguageTerritory = t.LearningLanguageTerritory,
                    Details = t.Details,
                    Editor = t.User.Username,
                    Level = t.Level.LevelCode
                });
        }
    }
}
