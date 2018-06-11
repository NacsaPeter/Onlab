using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Course")]
    public class DbCourse
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseName { get; set; }

        [StringLength(100)]
        public string Details { get; set; }

        [Required]
        [StringLength(2)]
        public string KnownLanguage { get; set; }

        public virtual DbLanguage KnownLanguageFull { get; set; }

        [StringLength(2)]
        public string KnownLanguageTerritory { get; set; }

        public virtual DbTerritory KnownLanguageTerritoryFull { get; set; }

        [Required]
        [StringLength(2)]
        public string LearningLanguage { get; set; }

        public virtual DbLanguage LearningLanguageFull { get; set; }

        [StringLength(2)]
        public string LearningLanguageTerritory { get; set; }

        public virtual DbTerritory LearnigLanguageTerritoryFull { get; set; }

        [ForeignKey(nameof(Level))]
        public int? LevelID { get; set; }

        public virtual DbCourseLevel Level { get; set; }

        [Column("Editor")]
        [ForeignKey(nameof(User))]
        public int? UserID { get; set; }

        public virtual DbUser User { get; set; }

        public virtual ICollection<DbTest> Tests { get; set; }

        public virtual ICollection<DbEnrollment> Enrollments { get; set; }
    }
}
