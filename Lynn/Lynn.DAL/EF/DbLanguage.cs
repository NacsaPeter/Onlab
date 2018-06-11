using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Language")]
    public class DbLanguage
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(2)]
        public string Code { get; set; }

        public virtual ICollection<DbCourse> CoursesAsKnown { get; set; }
        public virtual ICollection<DbCourse> CoursesAsLearning { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
