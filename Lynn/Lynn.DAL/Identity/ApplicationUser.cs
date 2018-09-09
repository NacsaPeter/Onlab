using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int Points { get; set; }

        public virtual ICollection<DbCourse> CreatedCourses { get; set; }
        public virtual ICollection<DbTestUser> TestTryings { get; set; }
        public virtual ICollection<DbEnrollment> Enrollments { get; set; }
    }
}
