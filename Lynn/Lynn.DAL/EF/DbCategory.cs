using Lynn.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lynn.DAL
{
    [Table("Categories")]
    public class DbCategory : IDbEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DbTest> Tests { get; set; }

    }
}
