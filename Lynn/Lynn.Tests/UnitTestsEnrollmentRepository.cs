using AutoMapper;
using Lynn.BLL;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Lynn.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Lynn.Tests
{
    public class UnitTestsEnrollmentRepository
    {
        private readonly IEnrollmentRepository _repo;
        private readonly DbContextOptions<LynnDb> _options;

        public UnitTestsEnrollmentRepository()
        {
            _options = new DbContextOptionsBuilder<LynnDb>()
                .UseInMemoryDatabase(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=EFProviders.InMemory;Integrated Security=True")
                .Options;
            _repo = new EnrollmentRepository(new LynnDb(_options));
        }

        [Fact]
        public void TestGetUserById()
        {
            using (var context = new LynnDb(_options))
            {
                context.Users.Add(new DbUser { ID = 1, Username = "Test", Email = "test@lynn.com" });
                context.SaveChanges();
            }

            var user = _repo.GetUserByID(1);
            Assert.Equal("Test", user.Username);
            Assert.Equal("test@lynn.com", user.Email);
        }

        [Fact]
        public void TestGetCoursesByName()
        {
            using (var context = new LynnDb(_options))
            {
                context.Courses.Add(new DbCourse { CourseName = "a" });
                context.Courses.Add(new DbCourse { CourseName = "ab" });
                context.Courses.Add(new DbCourse { CourseName = "b" });
                context.SaveChanges();
            }

            var courses = _repo.GetCoursesByName("a");
            int count = 0;
            foreach (var course in courses)
            {
                count++;
            }
            Assert.Equal(2, count);
        }

        [Fact]
        public void TestGetEnrollmentById()
        {
            using (var context = new LynnDb(_options))
            {
                context.Enrollments.Add(new DbEnrollment { ID = 5, CourseID = 1, UserID = 2, Level = 3 });
                context.SaveChanges();
            }

            var enrollment = _repo.GetEnrollmentById(5);
            Assert.Equal(1, enrollment.CourseID);
            Assert.Equal(2, enrollment.UserID);
            Assert.Equal(3, enrollment.Level);
        }

        [Fact]
        public void TestEnrollCourse()
        {
            var enrollment = new DbEnrollment { ID = 45, CourseID = 41, UserID = 42 };
            var enrollmentResult = _repo.EnrollCourse(enrollment);
            var enrollmentGet = _repo.GetEnrollmentById(45);

            Assert.Equal(41, enrollmentResult.CourseID);
            Assert.Equal(41, enrollmentGet.CourseID);
            Assert.Equal(42, enrollmentResult.UserID);
            Assert.Equal(42, enrollmentGet.UserID);
            Assert.Equal(45, enrollmentResult.ID);
            Assert.Equal(45, enrollmentGet.ID);
        }

        [Fact]
        public void TestGetEditorByCourseId()
        {
            using (var context = new LynnDb(_options))
            {
                context.Users.Add(new DbUser { ID = 23, Username = "Test" });
                context.Courses.Add(new DbCourse { ID = 21, UserID = 23, CourseName = "TestCourse" });
                context.SaveChanges();
            }

            var editor = _repo.GetEditorByCourseId(21);
            Assert.Equal("Test", editor.Username);
        }

        [Fact]
        public void TestGetCourseLevelByCourseId()
        {
            using (var context = new LynnDb(_options))
            {
                context.CourseLevels.Add(new DbCourseLevel { ID = 12, LevelCode = "A2" });
                context.Courses.Add(new DbCourse { ID = 11, LevelID = 12, CourseName = "TestCourse" });
                context.SaveChanges();
            }

            var level = _repo.GetCourseLevelByCourseId(11);
            Assert.Equal("A2", level.LevelCode);
        }

    }
}
