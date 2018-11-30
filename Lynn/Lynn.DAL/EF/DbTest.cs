using Lynn.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Tests")]
    public class DbTest : IDbEntry
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int? MaxPoints { get; set; }
        public int? NumberOfQuestions { get; set; }

        public int CourseId { get; set; }
        public virtual DbCourse Course { get; set; }

        public int? CategoryId { get; set; }
        public virtual DbCategory Category { get; set; }

        public virtual ICollection<DbVocabularyExercise> VocabularyExercises { get; set; }
        public virtual ICollection<DbGrammarExercise> GrammarExercises { get; set; }
        public virtual ICollection<DbTestUser> UserTests { get; set; }
        public virtual ICollection<DbRule> Rules { get; set; }
    }
}
