using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<DbEnrollment>
    {
        public void Configure(EntityTypeBuilder<DbEnrollment> builder)
        {
            builder.HasAlternateKey(e => new { e.UserId, e.CourseId });
        }
    }
}
