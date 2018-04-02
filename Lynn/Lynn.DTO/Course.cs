using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "Course")]
    public class Course
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "courseName")]
        public string CourseName { get; set; }

        [DataMember(Name = "knownLanguage")]
        public string KnownLanguage { get; set; }

        [DataMember(Name = "learningLanguage")]
        public string LearningLanguage { get; set; }
    }
}
