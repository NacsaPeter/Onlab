using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("CourseLevel")]
    public class DbCourseLevel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string LevelName { get; set; }

        public virtual ICollection<DbCourse> Courses { get; set; }
    }
}
