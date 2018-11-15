using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "TestResultDto")]
    public class TestResultDto
    {
        [DataMember(Name = "rightAnswers")]
        public int RightAnswers { get; set; }

        [DataMember(Name = "wrongAnswers")]
        public int WrongAnswers { get; set; }

        [DataMember(Name = "points")]
        public int Points { get; set; }
    }
}
