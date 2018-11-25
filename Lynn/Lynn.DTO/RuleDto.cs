using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "RuleDto")]
    public class RuleDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "explanation")]
        public string Explanation { get; set; }

        [DataMember(Name = "translatedExplanation")]
        public string TranslatedExplanation { get; set; }
    }
}
