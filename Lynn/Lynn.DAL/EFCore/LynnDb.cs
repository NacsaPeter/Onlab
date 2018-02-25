using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
namespace Lynn.DAL
{
    internal class LynnDb : DbContext
    {
        public DbSet<DbCategory> Catergories { get; set; }
        public DbSet<DbCourse> Courses { get; set; }
        public DbSet<DbCourseLevel> CourseLevels { get; set; }
        public DbSet<DbEnrollment> Enrollments { get; set; }
        public DbSet<DbExercise> Exercises { get; set; }
        public DbSet<DbGrammarExercise> GrammarExercises { get; set; }
        public DbSet<DbRule> Rules { get; set; }
        public DbSet<DbTest> Tests { get; set; }
        public DbSet<DbTestUser> TestTryings { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbVocabularyExercise> VocabularyExercises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LynnDB;Trusted_Connection=True;");
        }
    }
}

