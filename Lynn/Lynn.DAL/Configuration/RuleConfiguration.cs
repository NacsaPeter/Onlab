using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class RuleConfiguration : IEntityTypeConfiguration<DbRule>
    {
        public void Configure(EntityTypeBuilder<DbRule> builder)
        {
            builder.Property(r => r.TranslatedExplanation).IsRequired();
        }
    }
}
