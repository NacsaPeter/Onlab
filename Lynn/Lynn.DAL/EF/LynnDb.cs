using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
namespace Lynn.DAL
{
    public class LynnDb : DbContext
    {
        public DbSet<DbCategory> Catergories { get; set; }
        public DbSet<DbCourse> Courses { get; set; }
        public DbSet<DbCourseLevel> CourseLevels { get; set; }
        public DbSet<DbEnrollment> Enrollments { get; set; }
        public DbSet<DbGrammarExercise> GrammarExercises { get; set; }
        public DbSet<DbLanguage> Languages { get; set; }
        public DbSet<DbRule> Rules { get; set; }
        public DbSet<DbTerritory> Territories { get; set; }
        public DbSet<DbTest> Tests { get; set; }
        public DbSet<DbTestUser> TestTryings { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbVocabularyExercise> VocabularyExercises { get; set; }

        public LynnDb(DbContextOptions<LynnDb> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>().HasAlternateKey(u => u.Username);
            modelBuilder.Entity<DbTestUser>().HasAlternateKey(t => new { t.TestID, t.UserID });
            modelBuilder.Entity<DbTerritory>().HasAlternateKey(t => t.Code);
            modelBuilder.Entity<DbLanguage>().HasAlternateKey(l => l.Code);
            modelBuilder.Entity<DbEnrollment>().HasAlternateKey(e => new { e.UserID, e.CourseID });
            modelBuilder.Entity<DbTerritory>().HasAlternateKey(t => t.Code);
            modelBuilder.Entity<DbCourseLevel>().HasAlternateKey(l => l.LevelCode);

            modelBuilder.Entity<DbCourse>().HasOne(c => c.KnownLanguageFull).WithMany(l => l.CoursesAsKnown);
            modelBuilder.Entity<DbCourse>().HasOne(c => c.KnownLanguageTerritoryFull).WithMany(t => t.CoursesAsKnown);
            modelBuilder.Entity<DbCourse>().HasOne(c => c.LearningLanguageFull).WithMany(l => l.CoursesAsLearning);
            modelBuilder.Entity<DbCourse>().HasOne(c => c.LearnigLanguageTerritoryFull).WithMany(t => t.CoursesAsLearning);

            modelBuilder.Entity<DbUser>().HasIndex(u => u.Email);
            modelBuilder.Entity<DbCategory>().HasIndex(c => c.Name);
            modelBuilder.Entity<DbCourseLevel>().HasIndex(l => l.LevelName);
            modelBuilder.Entity<DbRule>().HasIndex(r => r.Name);
            modelBuilder.Entity<DbCourse>().HasIndex(c => c.CourseName);

            modelBuilder.Entity<DbTestUser>(t =>
            {
                t.OwnsOne(x => x.BestResult);
                t.OwnsOne(x => x.LastResult);
            });
        }
    }
}

