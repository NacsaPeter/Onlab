using AutoMapper;
using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL
{
    public class LanguageManager
    {
        private readonly ILanguageRepository _repo;
        private readonly IMapper _mapper;

        public LanguageManager(ILanguageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ICollection<Language>> GetLanguages()
        {
            return _mapper.Map<ICollection<Language>>(await _repo.GetLanguagesAsync());
        }

        public async Task<ICollection<Territory>> GetTerritories()
        {
            return _mapper.Map<ICollection<Territory>>(await _repo.GetTerritoriesAsync());
        }

        public async Task<ICollection<CourseLevelDto>> GetCourseLevels()
        {
            return _mapper.Map<ICollection<CourseLevelDto>>(await _repo.GetCourseLevelsAsync());
        }
    }
}
