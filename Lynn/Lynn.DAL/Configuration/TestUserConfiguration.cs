using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class TestUserConfiguration : IEntityTypeConfiguration<DbTestUser>
    {
        public void Configure(EntityTypeBuilder<DbTestUser> builder)
        {
            builder.HasAlternateKey(t => new { t.TestId, t.UserId });
            builder.OwnsOne(t => t.BestResult);
            builder.OwnsOne(t => t.LastResult);
        }
    }
}
