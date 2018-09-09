using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Lynn.DAL.Interfaces;

namespace Lynn.DAL
{
    [Table("VocabularyExercises")]
    public class DbVocabularyExercise : IDbExercise
    {
        public int Id { get; set; }

        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }

        public string TranslatedCorrectAnswer { get; set; }
        public string TranslatedWrongAnswer1 { get; set; }
        public string TranslatedWrongAnswer2 { get; set; }
        public string TranslatedWrongAnswer3 { get; set; }

        public string Sentence { get; set; }
        public string TranslatedSentence { get; set; }

        public string Picture { get; set; }
        public string Video { get; set; }
        public string Audio { get; set; }

        public int TestId { get; set; }
        public virtual DbTest Test { get; set; }
    }
}
