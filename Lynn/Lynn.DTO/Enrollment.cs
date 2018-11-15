using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "Enrollment")]
    public class Enrollment
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "courseId")]
        public int CourseId { get; set; }

        [DataMember(Name = "userId")]
        public int UserId { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "points")]
        public int Points { get; set; }
    }
}
