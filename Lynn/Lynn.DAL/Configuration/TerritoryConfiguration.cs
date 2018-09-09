using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class TerritoryConfiguration : IEntityTypeConfiguration<DbTerritory>
    {
        public void Configure(EntityTypeBuilder<DbTerritory> builder)
        {
            builder.HasAlternateKey(l => l.Code);
            builder.Property(l => l.Code).HasMaxLength(2);
            builder.Property(l => l.Name).IsRequired();
        }
    }
}
