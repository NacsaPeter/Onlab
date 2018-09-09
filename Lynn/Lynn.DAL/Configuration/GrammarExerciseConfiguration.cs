using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class GrammarExerciseConfiguration : IEntityTypeConfiguration<DbGrammarExercise>
    {
        public void Configure(EntityTypeBuilder<DbGrammarExercise> builder)
        {
            builder.Property(e => e.Question).IsRequired();
            builder.Property(e => e.CorrectAnswer).IsRequired();
            builder.Property(e => e.WrongAnswer1).IsRequired();
            builder.Property(e => e.WrongAnswer2).IsRequired();
            builder.Property(e => e.WrongAnswer3).IsRequired();
        }
    }
}
