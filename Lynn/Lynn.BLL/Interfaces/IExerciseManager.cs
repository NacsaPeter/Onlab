using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Interfaces
{
    public interface IExerciseManager
    {
        Task<ICollection<VocabularyExercise>> GetVocabularyExercisesAsync(int testId);
        Task<ICollection<GrammarExercise>> GetGrammarExercisesAsync(int testId);
        Task<ICollection<RuleDto>> GetGrammarRulesAsync(int testId);

        Task<GrammarExercise> CreateGrammarExerciseAsync(GrammarExercise grammarExercise);
        Task<GrammarExercise> EditGrammarExerciseAsync(GrammarExercise grammarExercise);
        Task<bool> DeleteGrammarExerciseAsync(int id);

        Task<VocabularyExercise> CreateVocabularyExerciseAsync(VocabularyExercise vocabularyExercise);
        Task<VocabularyExercise> EditVocabularyExerciseAsync(VocabularyExercise vocabularyExercise);
        Task<bool> DeleteVocabularyExerciseAsync(int id);

        Task<RuleDto> CreateRuleAsync(RuleDto rule);
        Task<RuleDto> EditRuleAsync(RuleDto rule);
        Task<bool> DeleteRuleAsync(int id);
    }
}
