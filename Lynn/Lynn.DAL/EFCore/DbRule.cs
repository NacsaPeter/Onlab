using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Rule")]
    public class DbRule
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        [StringLength(200)]
        public string Explanation { get; set; }

        [Required]
        [StringLength(200)]
        public string TranslatedExplanation { get; set; }

        public virtual ICollection<DbGrammarExercise> GrammarExercises { get; set; }
    }
}
