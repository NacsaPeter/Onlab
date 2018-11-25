using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "GrammarExercise")]
    public class GrammarExercise
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "question")]
        public string Question { get; set; }

        [DataMember(Name = "correctAnswer")]
        public string CorrectAnswer { get; set; }

        [DataMember(Name = "wrongAnswer1")]
        public string WrongAnswer1 { get; set; }

        [DataMember(Name = "wrongAnswer2")]
        public string WrongAnswer2 { get; set; }

        [DataMember(Name = "wrongAnswer3")]
        public string WrongAnswer3 { get; set; }
    }
}
