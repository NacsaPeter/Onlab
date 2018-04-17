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

        [DataMember(Name = "knownLanguageTerritory")]
        public string KnownLanguageTerritory { get; set; }

        [DataMember(Name = "learningLanguage")]
        public string LearningLanguage { get; set; }

        [DataMember(Name = "learningLanguageTerritory")]
        public string LearningLanguageTerritory { get; set; }

        [DataMember(Name = "level")]
        public string Level { get; set; }

        [DataMember(Name = "editor")]
        public string Editor { get; set; }

        [DataMember(Name = "details")]
        public string Details { get; set; }
    }
}
