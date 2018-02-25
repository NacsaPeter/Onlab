using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lynn.DAL
{
    [Table("GrammarExercise")]
    internal class DbGrammarExercise : DbExercise
    {
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
