using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DTO
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public int Level { get; set; }
        public int Points { get; set; }
    }
}
