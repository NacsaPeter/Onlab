using Lynn.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("GrammarExercises")]
    public class DbGrammarExercise : IDbExercise
    {
        public int Id { get; set; }

        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }

        public int TestId { get; set; }
        public virtual DbTest Test { get; set; }

        public int? RuleId { get; set; }
        public virtual DbRule Rule { get; set; }
    }
}
