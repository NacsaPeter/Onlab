using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<DbCategory>
    {
        public void Configure(EntityTypeBuilder<DbCategory> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
