using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lynn.DAL
{
    [Table("Territory")]
    public class DbTerritory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(2)]
        public string Code { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
