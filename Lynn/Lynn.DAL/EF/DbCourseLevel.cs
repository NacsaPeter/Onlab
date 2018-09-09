using Lynn.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("CourseLevels")]
    public class DbCourseLevel : IDbEntry
    {
        public int Id { get; set; }
        public string LevelCode { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<DbCourse> Courses { get; set; }
    }
}
