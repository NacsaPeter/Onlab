using Lynn.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Rules")]
    public class DbRule : IDbEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public string TranslatedExplanation { get; set; }

        public virtual ICollection<DbGrammarExercise> GrammarExercises { get; set; }
    }
}
