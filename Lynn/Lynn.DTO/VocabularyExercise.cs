using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "VocabularyExercise")]
    public class VocabularyExercise
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "testID")]
        public int TestID { get; set; }

        [DataMember(Name = "correctAnswer")]
        public string CorrectAnswer { get; set; }

        [DataMember(Name = "translatedCorrectAnswer")]
        public string TranslatedCorrectAnswer { get; set; }

        [DataMember(Name = "wrongAnswer1")]
        public string WrongAnswer1 { get; set; }

        [DataMember(Name = "wrongAnswer2")]
        public string WrongAnswer2 { get; set; }

        [DataMember(Name = "wrongAnswer3")]
        public string WrongAnswer3 { get; set; }

        [DataMember(Name = "translatedWrongAnswer1")]
        public string TranslatedWrongAnswer1 { get; set; }

        [DataMember(Name = "translatedWrongAnswer2")]
        public string TranslatedWrongAnswer2 { get; set; }

        [DataMember(Name = "translatedWrongAnswer3")]
        public string TranslatedWrongAnswer3 { get; set; }

        [DataMember(Name ="sentence")]
        public string Sentence { get; set; }

        [DataMember(Name = "translatedSentence")]
        public string TranslatedSentence { get; set; }

        [DataMember(Name = "picture")]
        public string Picture { get; set; }
    }
}
