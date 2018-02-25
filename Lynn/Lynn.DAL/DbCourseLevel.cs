using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("CourseLevel")]
    internal class DbCourseLevel
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string LevelName { get; set; }

        public virtual ICollection<DbCourse> Courses { get; set; }
    }
}
