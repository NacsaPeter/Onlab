using Lynn.DAL.Identity;
using Lynn.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Enrollments")]
    public class DbEnrollment : IDbEntry
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Points { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int CourseId { get; set; }
        public virtual DbCourse Course { get; set; }
    }
}
