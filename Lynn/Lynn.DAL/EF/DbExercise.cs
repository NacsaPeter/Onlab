using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    public abstract class DbExercise
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
    }
}
