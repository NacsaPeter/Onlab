using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "TestTrying")]
    public class TestTrying
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "attempts")]
        public int Attempts { get; set; }

        [DataMember(Name = "isCorrect")]
        public bool IsCorrect { get; set; }

        [DataMember(Name = "bestResult")]
        public TestResultDto BestResult { get; set; }

        [DataMember(Name = "lastResult")]
        public TestResultDto LastResult { get; set; }

        [DataMember(Name = "userId")]
        public int UserId { get; set; }

        [DataMember(Name = "testId")]
        public int TestId { get; set; }
    }
}
