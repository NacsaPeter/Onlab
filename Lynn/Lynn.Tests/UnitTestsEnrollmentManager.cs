using Lynn.BLL;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lynn.Tests
{
    public class UnitTestsEnrollmentManager
    {
        private readonly EnrollmentManager _manager;
        private readonly DbContextOptions<LynnDb> _options;

        public UnitTestsEnrollmentManager()
        {
            _options = new DbContextOptionsBuilder<LynnDb>()
                .UseInMemoryDatabase(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=EFProviders.InMemory;Integrated Security=True")
                .Options;
            _manager = new EnrollmentManager(new EnrollmentRepository(new LynnDb(_options)), MapperConfig.Configure());
        }

        [Fact]
        public void TestGetEnrollmentById()
        {
            using (var context = new LynnDb(_options))
            {
                context.Enrollments.Add(new DbEnrollment { ID = 65, CourseID = 61, UserID = 62 });
                context.SaveChanges();
            }

            var enrollment = _manager.GetEnrollmentById(65);
            Assert.Equal(61, enrollment.CourseID);
            Assert.Equal(62, enrollment.UserID);
        }

        [Fact]
        public void TestGetCoursesByName()
        {
            using (var context = new LynnDb(_options))
            {
                context.Users.Add(new DbUser { ID = 71, Username = "Test" });
                context.CourseLevels.Add(new DbCourseLevel { ID = 1, LevelCode = "A1" });
                context.Courses.Add(new DbCourse { CourseName = "x", UserID = 71, LevelID = 1 });
                context.Courses.Add(new DbCourse { CourseName = "xy", UserID = 71, LevelID = 1 });
                context.Courses.Add(new DbCourse { CourseName = "y", UserID = 71, LevelID = 1 });
                context.SaveChanges();
            }

            var courses = _manager.GetCoursesByName("x");
            int count = 0;
            foreach (var course in courses)
            {
                count++;
            }
            Assert.Equal(2, count);
        }
    }
}
