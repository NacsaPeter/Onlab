using Lynn.DAL.Identity;
using Lynn.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Courses")]
    public class DbCourse : IDbEntry
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Details { get; set; }
        public string TeachingLanguage { get; set; }
        public string TeachingLanguageTerritory { get; set; }
        public string LearningLanguage { get; set; }
        public string LearningLanguageTerritory { get; set; }

        public int? LevelId { get; set; }
        public virtual DbCourseLevel Level { get; set; }

        public int? EditorId { get; set; }
        public virtual ApplicationUser Editor { get; set; }

        public virtual ICollection<DbTest> Tests { get; set; }
        public virtual ICollection<DbEnrollment> Enrollments { get; set; }
    }
}
