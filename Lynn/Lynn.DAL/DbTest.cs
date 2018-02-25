using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Test")]
    internal class DbTest
    {
        [Key]
        public int ID { get; set; }

        public int Level { get; set; }

        public int MaxPoints { get; set; }
        
        public int NumberOfQuestions { get; set; }

        [Required]
        [ForeignKey(nameof(Course))]
        public int? CourseID { get; set; }

        public virtual DbCourse Course { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryID { get; set; }

        public virtual DbCategory Category { get; set; }

        public virtual ICollection<DbExercise> Exercises { get; set; }

        public virtual ICollection<DbTestUser> UserTests { get; set; }
    }
}
