using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Enrollment")]
    public class DbEnrollment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int? UserID { get; set; }

        public virtual DbUser User { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int? CourseID { get; set; }

        public virtual DbCourse Course { get; set; }

        public int Level { get; set; }

        public int Points { get; set; }
    }
}
