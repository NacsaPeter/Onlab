using AutoMapper;
using Lynn.BLL.Interfaces;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Managers
{
    public class LanguageManager: ILanguageManager
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageManager(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Language>> GetLanguages()
        {
            return _mapper.Map<ICollection<Language>>(await _languageRepository.GetLanguagesAsync());
        }

        public async Task<ICollection<Territory>> GetTerritories()
        {
            return _mapper.Map<ICollection<Territory>>(await _languageRepository.GetTerritoriesAsync());
        }

        public async Task<ICollection<CourseLevelDto>> GetCourseLevels()
        {
            return _mapper.Map<ICollection<CourseLevelDto>>(await _languageRepository.GetCourseLevelsAsync());
        }
    }
}
