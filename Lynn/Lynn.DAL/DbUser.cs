using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lynn.DAL
{
    [Table("User")]
    internal class DbUser
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [StringLength(80)]
        public string PasswordHash { get; set; }

        public int Points { get; set; }

        public virtual ICollection<DbCourse> CreatedCourses { get; set; }

        public virtual ICollection<DbTestUser> TestTryings { get; set; }

        public virtual ICollection<DbEnrollment> Enrollments { get; set; }
    }
}
