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
    public class ExerciseManager: IExerciseManager
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseManager(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GrammarExercise>> GetGrammarExercisesAsync(int testId)
        {
            return _mapper.Map<ICollection<GrammarExercise>>(
                await _exerciseRepository.GetGrammarExercisesByTestIdAsync(testId));
        }

        public async Task<ICollection<RuleDto>> GetGrammarRulesAsync(int testId)
        {
            return _mapper.Map<ICollection<RuleDto>>(
                await _exerciseRepository.GetGrammarRulesByTestIdAsync(testId));
        }

        public async Task<ICollection<VocabularyExercise>> GetVocabularyExercisesAsync(int testId)
        {
            return _mapper.Map<ICollection<VocabularyExercise>>(
                await _exerciseRepository.GetVocabularyExercisesByTestIdAsync(testId));
        }
    }
}
