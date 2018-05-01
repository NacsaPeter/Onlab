using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("GrammarExercise")]
    public class DbGrammarExercise
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
        [StringLength(100)]
        public string Question { get; set; }

        [Required]
        [StringLength(50)]
        public string CorrectAnswer { get; set; }

        [ForeignKey(nameof(Rule))]
        public int? RuleID { get; set; }

        public virtual DbRule Rule { get; set; }
    }
}
