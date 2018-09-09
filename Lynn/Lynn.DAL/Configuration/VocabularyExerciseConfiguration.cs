using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Configuration
{
    public class VocabularyExerciseConfiguration : IEntityTypeConfiguration<DbVocabularyExercise>
    {
        public void Configure(EntityTypeBuilder<DbVocabularyExercise> builder)
        {
            builder.Property(e => e.CorrectAnswer).IsRequired();
            builder.Property(e => e.WrongAnswer1).IsRequired();
            builder.Property(e => e.WrongAnswer2).IsRequired();
            builder.Property(e => e.WrongAnswer3).IsRequired();
            builder.Property(e => e.TranslatedCorrectAnswer).IsRequired();
            builder.Property(e => e.TranslatedWrongAnswer1).IsRequired();
            builder.Property(e => e.TranslatedWrongAnswer2).IsRequired();
            builder.Property(e => e.TranslatedWrongAnswer3).IsRequired();
        }
    }
}
