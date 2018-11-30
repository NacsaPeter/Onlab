using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface IExerciseRepository
    {
        Task<ICollection<DbVocabularyExercise>> GetVocabularyExercisesByTestIdAsync(int testId);
        Task<ICollection<DbGrammarExercise>> GetGrammarExercisesByTestIdAsync(int testId);
        Task<ICollection<DbRule>> GetGrammarRulesByTestIdAsync(int testId);

        Task<DbVocabularyExercise> CreateVocabularyExerciseAsync(DbVocabularyExercise vocabularyExercise);
        Task<DbVocabularyExercise> EditVocabularyExerciseAsync(DbVocabularyExercise vocabularyExercise);
        Task<bool> DeleteVocabularyExerciseAsync(int id);

        Task<DbGrammarExercise> CreateGrammarExerciseAsync(DbGrammarExercise grammarExercise);
        Task<DbGrammarExercise> EditGrammarExerciseAsync(DbGrammarExercise grammarExercise);
        Task<bool> DeleteGrammarExerciseAsync(int id);

        Task<DbRule> CreateRuleAsync(DbRule rule);
        Task<DbRule> EditRuleAsync(DbRule rule);
    }
}
