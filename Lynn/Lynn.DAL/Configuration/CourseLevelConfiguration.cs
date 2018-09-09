using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class CourseLevelConfiguration : IEntityTypeConfiguration<DbCourseLevel>
    {
        public void Configure(EntityTypeBuilder<DbCourseLevel> builder)
        {
            builder.HasAlternateKey(l => l.LevelCode);
            builder.Property(l => l.LevelCode).HasMaxLength(2);
        }
    }
}
