using Lynn.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lynn.Tests
{
    public class UnitTestsCourseRepository
    {
        private readonly ICourseRepository _repo;
        private readonly DbContextOptions<LynnDb> _options;

        public UnitTestsCourseRepository()
        {
            _options = new DbContextOptionsBuilder<LynnDb>()
                .UseInMemoryDatabase(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=EFProviders.InMemory;Integrated Security=True")
                .Options;
            _repo = new CourseRepository(new LynnDb(_options));
        }

        [Fact]
        public void TestGetTestsByCourseId()
        {
            using (var context = new LynnDb(_options))
            {
                context.Courses.Add(new DbCourse { ID = 31, CourseName = "TestCourse" });
                context.Tests.Add(new DbTest { ID = 35, CourseID = 31 });
                context.Tests.Add(new DbTest { ID = 37, CourseID = 31 });
                context.Tests.Add(new DbTest { ID = 39, CourseID = 36 });
                context.SaveChanges();
            }

            var tests = _repo.GetTestsByCourseId(31);
            int count = 0;
            foreach (var test in tests)
            {
                count++;
            }
            Assert.Equal(2, count);
        }

        [Fact]
        public void TestGetCategoryByTestId()
        {
            using (var context = new LynnDb(_options))
            {
                context.Tests.Add(new DbTest { ID = 5, CategoryID = 2 });
                context.Catergories.Add(new DbCategory { ID = 2, Name = "Tests" });
                context.SaveChanges();
            }

            var category = _repo.GetCategoryByTestId(5);
            Assert.Equal("Tests", category.Name);
        }

        [Fact]
        public void TestGetVocabularyExercisesByTestId()
        {
            using (var context = new LynnDb(_options))
            {
                context.Tests.Add(new DbTest { ID = 85 });
                context.VocabularyExercises.Add(new DbVocabularyExercise { ID = 81, TestID = 85 });
                context.VocabularyExercises.Add(new DbVocabularyExercise { ID = 82, TestID = 86 });
                context.SaveChanges();
            }

            var exercises = _repo.GetVocabularyExercisesByTestId(85);
            int count = 0;
            foreach (var exercise in exercises)
            {
                count++;
            }
            Assert.Equal(1, count);
        }
    }
}
