using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<DbCourse>
    {
        public void Configure(EntityTypeBuilder<DbCourse> builder)
        {
            builder.HasAlternateKey(c => c.CourseName);
            builder.Property(c => c.TeachingLanguage).HasMaxLength(2).IsRequired();
            builder.Property(c => c.TeachingLanguageTerritory).HasMaxLength(2);
            builder.Property(c => c.LearningLanguage).HasMaxLength(2).IsRequired();
            builder.Property(c => c.LearningLanguageTerritory).HasMaxLength(2);
        }
    }
}
