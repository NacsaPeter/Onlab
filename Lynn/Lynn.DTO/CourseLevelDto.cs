using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "CourseLevelDto")]
    public class CourseLevelDto
    {
        [DataMember(Name = "levelCode")]
        public string LevelCode { get; set; }

        [DataMember(Name = "levelName")]
        public string LevelName { get; set; }
    }
}
