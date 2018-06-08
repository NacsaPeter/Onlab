using Lynn.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.BLL
{
    public class LanguageManager
    {
        private readonly ICourseRepository _repo;

        public LanguageManager(ICourseRepository repo)
        {
            _repo = repo;
        }

        public Dictionary<string, string> GetLanguageCodeDictionary()
        {
            return _repo.GetLanguageCodeDictionary();
        }

        public Dictionary<string, string> GetTerritoryCodeDictionary()
        {
            return _repo.GetTerritoryCodeDictionary();
        }
    }
}
