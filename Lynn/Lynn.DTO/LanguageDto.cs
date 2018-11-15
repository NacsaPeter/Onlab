using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lynn.DTO
{
    [DataContract(Name = "LanguageDto")]
    public class LanguageDto
    {
        [DataMember(Name = "language")]
        public Language Language { get; set; }

        [DataMember(Name = "territory")]
        public Territory Territory { get; set; }
    }
}
