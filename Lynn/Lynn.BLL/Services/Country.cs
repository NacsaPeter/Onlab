using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lynn.BLL.Services
{
    public class Country
    {
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public ObservableCollection<Language> Languages { get; set; }
    }

    public class Language
    {
        public string Iso639_1 { get; set; }
        public string Iso639_2 { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
    }
}
