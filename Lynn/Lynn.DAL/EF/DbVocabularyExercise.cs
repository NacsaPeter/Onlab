using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lynn.DAL
{
    [Table("VocabularyExercise")]
    public class DbVocabularyExercise
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey(nameof(Test))]
        public int TestID { get; set; }

        public virtual DbTest Test { get; set; }

        [Required]
        [StringLength(50)]
        public string WrongAnswer1 { get; set; }

        [Required]
        [StringLength(50)]
        public string WrongAnswer2 { get; set; }

        [Required]
        [StringLength(50)]
        public string WrongAnswer3 { get; set; }

        [Required]
        [StringLength(50)]
        public string Expression { get; set; }

        [Required]
        [StringLength(50)]
        public string TranslatedExpression { get; set; }

        [StringLength(100)]
        public string Sentence { get; set; }

        [StringLength(100)]
        public string TranslatedSentence { get; set; }

        [StringLength(100)]
        public string Picture { get; set; }

        [StringLength(100)]
        public string Video { get; set; }

        [StringLength(100)]
        public string Audio { get; set; }

        [Required]
        [StringLength(50)]
        public string TranslatedWrongAnswer1 { get; set; }

        [Required]
        [StringLength(50)]
        public string TranslatedWrongAnswer2 { get; set; }

        [Required]
        [StringLength(50)]
        public string TranslatedWrongAnswer3 { get; set; }
    }
}
