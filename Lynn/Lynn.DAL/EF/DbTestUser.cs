using Lynn.DAL.Identity;
using Lynn.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Tryings")]
    public class DbTestUser : IDbEntry
    {
        public int Id { get; set; }
        public int Attempts { get; set; }
        public bool IsCorrect { get; set; }

        public DbTestResult BestResult { get; set; }
        public DbTestResult LastResult { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int TestId { get; set; }
        public virtual DbTest Test { get; set; }
    }
}
