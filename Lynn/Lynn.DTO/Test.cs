using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "Test")]
    public class Test
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "categoryName")]
        public string CategoryName { get; set; }

        [DataMember(Name = "courseID")]
        public int CourseID { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "maxPoints")]
        public int MaxPoints { get; set; }

        [DataMember(Name = "numberOfQuestions")]
        public int NumberOfQuestions { get; set; }
    }
}
