using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Tryings")]
    public class DbTestUser
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int? UserID { get; set; }

        public virtual DbUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Test))]
        public int? TestID { get; set; }

        public virtual DbTest Test { get; set; }

        public int Attempts { get; set; }

        public bool IsCorrect { get; set; }
    }
}
