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
        public int Id { get; set; }

        [DataMember(Name = "courseName")]
        public string CourseName { get; set; }

        [DataMember(Name = "teachingLanguage")]
        public LanguageDto TeachingLanguage { get; set; }

        [DataMember(Name = "learningLanguage")]
        public LanguageDto LearningLanguage { get; set; }

        [DataMember(Name = "level")]
        public CourseLevelDto Level { get; set; }

        [DataMember(Name = "editor")]
        public string Editor { get; set; }

        [DataMember(Name = "details")]
        public string Details { get; set; }
    }
}
