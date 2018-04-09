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

        public Enrollment GetEnrollmentById(int enrollmentId)
        {
            using (var db = getDB())
            {
                return (from t in db.Enrollments.Where(t => t.ID == enrollmentId)
                       select new Enrollment
                       {
                           ID = t.ID,
                           CourseId = t.CourseID,
                           UserId = t.UserID,
                           Level = t.Level,
                           Points = t.Points
                       })
                       .Single();
            }
        }

        public IEnumerable<Course> GetEnrolledCourses(User user)
        {
            using (var db = getDB())
            {
                return (from t1 in db.Enrollments
                       join t2 in db.Courses on t1.CourseID equals t2.ID
                       where t1.UserID == user.ID
                       select new Course
                       {
                           ID = t2.ID,
                           CourseName = t2.CourseName,
                           KnownLanguage = t2.KnownLanguage,
                           LearningLanguage = t2.LearningLanguage
                       })
                       .ToList();

            }
        }

        public User GetUserByID(int id)
        {
            using (var db = getDB())
            {
                return (from t in db.Users
                        where t.ID == id
                        select new User
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

        public int GetNumberOfEnrollments(int userId)
        {
            using (var db = getDB())
            {
                return db.Enrollments.Count(x => x.UserID == userId);
            }
        }

        public int EnrollCourse(Enrollment enrollment)
        {
            using (var db = getDB())
            {
                var dbenrollment = new DbEnrollment
                {
                    CourseID = enrollment.CourseId,
                    UserID = enrollment.UserId,
                    Level = enrollment.Level,
                    Points = enrollment.Points
                };

                var result = db.Enrollments.Add(dbenrollment);
                db.SaveChanges();

                var enrollmentId = result.GetDatabaseValues().GetValue<int>("ID");
                return enrollmentId;
            }
        }

        public IEnumerable<Course> GetCoursesByName(string coursename)
        {
            using (var db = getDB())
            {
                return db.Courses
                    .Where(t => t.CourseName.Contains(coursename))
                    .Select(t => new Course {
                        CourseName = t.CourseName,
                        ID = t.ID,
                        KnownLanguage = t.KnownLanguage,
                        LearningLanguage = t.LearningLanguage
                    });
            }
        }
    }
}
