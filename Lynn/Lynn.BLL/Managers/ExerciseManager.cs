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

        public async Task<GrammarExercise> CreateGrammarExerciseAsync(GrammarExercise grammarExercise)
        {
            var dbGrammarExercise = _mapper.Map<DbGrammarExercise>(grammarExercise);
            return _mapper.Map<GrammarExercise>(
                await _exerciseRepository.CreateGrammarExerciseAsync(dbGrammarExercise));
        }

        public async Task<RuleDto> CreateRuleAsync(RuleDto rule)
        {
            var dbRule = _mapper.Map<DbRule>(rule);
            return _mapper.Map<RuleDto>(await _exerciseRepository.CreateRuleAsync(dbRule));
        }

        public async Task<VocabularyExercise> CreateVocabularyExerciseAsync(VocabularyExercise vocabularyExercise)
        {
            var dbVocabularyExercise = _mapper.Map<DbVocabularyExercise>(vocabularyExercise);
            return _mapper.Map<VocabularyExercise>(
                await _exerciseRepository.CreateVocabularyExerciseAsync(dbVocabularyExercise));
        }

        public async Task<bool> DeleteGrammarExerciseAsync(int id)
        {
            return await _exerciseRepository.DeleteGrammarExerciseAsync(id);
        }

        public async Task<bool> DeleteRuleAsync(int id)
        {
            return await _exerciseRepository.DeleteRuleAsync(id);
        }

        public async Task<bool> DeleteVocabularyExerciseAsync(int id)
        {
            return await _exerciseRepository.DeleteVocabularyExerciseAsync(id);
        }

        public async Task<GrammarExercise> EditGrammarExerciseAsync(GrammarExercise grammarExercise)
        {
            var dbGrammarExercise = _mapper.Map<DbGrammarExercise>(grammarExercise);
            return _mapper.Map<GrammarExercise>(
                await _exerciseRepository.EditGrammarExerciseAsync(dbGrammarExercise));
        }

        public async Task<RuleDto> EditRuleAsync(RuleDto rule)
        {
            var dbRule = _mapper.Map<DbRule>(rule);
            return _mapper.Map<RuleDto>(await _exerciseRepository.EditRuleAsync(dbRule));
        }

        public async Task<VocabularyExercise> EditVocabularyExerciseAsync(VocabularyExercise vocabularyExercise)
        {
            var dbVocabularyExercise = _mapper.Map<DbVocabularyExercise>(vocabularyExercise);
            return _mapper.Map<VocabularyExercise>(
                await _exerciseRepository.EditVocabularyExerciseAsync(dbVocabularyExercise));
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
