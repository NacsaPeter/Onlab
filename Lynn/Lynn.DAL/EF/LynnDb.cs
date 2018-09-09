using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Lynn.DAL.Identity;
using Lynn.DAL.Configuration;

namespace Lynn.DAL
{
    public class LynnDb : IdentityDbContext<ApplicationUser, ApplicationRole, int>
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
        public DbSet<DbVocabularyExercise> VocabularyExercises { get; set; }

        public LynnDb(DbContextOptions<LynnDb> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseLevelConfiguration());
            builder.ApplyConfiguration(new EnrollmentConfiguration());
            builder.ApplyConfiguration(new GrammarExerciseConfiguration());
            builder.ApplyConfiguration(new LanguageConfiguration());
            builder.ApplyConfiguration(new RuleConfiguration());
            builder.ApplyConfiguration(new TerritoryConfiguration());
            builder.ApplyConfiguration(new TestUserConfiguration());
            builder.ApplyConfiguration(new VocabularyExerciseConfiguration());
        }
    }
}

