using Lynn.DAL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly LynnDb _context;

        public ExerciseRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<DbGrammarExercise> CreateGrammarExerciseAsync(DbGrammarExercise grammarExercise)
        {
            if (grammarExercise == null || grammarExercise.Id != 0)
            {
                return null;
            }

            var test = await _context.Tests
                .Where(t => t.Id == grammarExercise.TestId)
                .SingleOrDefaultAsync();

            test.NumberOfQuestions++;
            _context.GrammarExercises.Add(grammarExercise);
            await _context.SaveChangesAsync();

            return grammarExercise;
        }

        public async Task<DbRule> CreateRuleAsync(DbRule rule)
        {
            if (rule == null || rule.Id != 0)
            {
                return null;
            }

            _context.Rules.Add(rule);
            await _context.SaveChangesAsync();

            return rule;
        }

        public async Task<DbVocabularyExercise> CreateVocabularyExerciseAsync(DbVocabularyExercise vocabularyExercise)
        {
            if (vocabularyExercise == null || vocabularyExercise.Id != 0)
            {
                return null;
            }

            var test = await _context.Tests
                .Where(t => t.Id == vocabularyExercise.TestId)
                .SingleOrDefaultAsync();

            test.NumberOfQuestions++;
            _context.VocabularyExercises.Add(vocabularyExercise);
            await _context.SaveChangesAsync();

            return vocabularyExercise;
        }

        public async Task<bool> DeleteGrammarExerciseAsync(int id)
        {
            var exercise = await _context.GrammarExercises
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            if (exercise == null)
            {
                return false;
            }

            var test = await _context.Tests
                .Where(t => t.Id == exercise.TestId)
                .SingleOrDefaultAsync();

            try
            {
                test.NumberOfQuestions--;
                _context.GrammarExercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteVocabularyExerciseAsync(int id)
        {
            var exercise = await _context.VocabularyExercises
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            if (exercise == null)
            {
                return false;
            }

            var test = await _context.Tests
                .Where(t => t.Id == exercise.TestId)
                .SingleOrDefaultAsync();

            try
            {
                test.NumberOfQuestions--;
                _context.VocabularyExercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<DbGrammarExercise> EditGrammarExerciseAsync(DbGrammarExercise grammarExercise)
        {
            var oldExercise = await _context.GrammarExercises
                .Where(e => e.Id == grammarExercise.Id)
                .SingleOrDefaultAsync();

            if (oldExercise == null)
            {
                return null;
            }

            if (oldExercise.Question != grammarExercise.Question)
            {
                oldExercise.Question = grammarExercise.Question;
            }
            if (oldExercise.CorrectAnswer != grammarExercise.CorrectAnswer)
            {
                oldExercise.CorrectAnswer = grammarExercise.CorrectAnswer;
            }
            if (oldExercise.RuleId != grammarExercise.RuleId)
            {
                oldExercise.RuleId = grammarExercise.RuleId;
            }
            if (oldExercise.WrongAnswer1 != grammarExercise.WrongAnswer1)
            {
                oldExercise.WrongAnswer1 = grammarExercise.WrongAnswer1;
            }
            if (oldExercise.WrongAnswer2 != grammarExercise.WrongAnswer2)
            {
                oldExercise.WrongAnswer2 = grammarExercise.WrongAnswer2;
            }
            if (oldExercise.WrongAnswer3 != grammarExercise.WrongAnswer3)
            {
                oldExercise.WrongAnswer3 = grammarExercise.WrongAnswer3;
            }

            try
            {
                _context.GrammarExercises.Update(oldExercise);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return grammarExercise;
        }

        public async Task<DbRule> EditRuleAsync(DbRule rule)
        {
            var oldRule = await _context.Rules
                .Where(r => r.Id == rule.Id)
                .SingleOrDefaultAsync();

            if (oldRule.Name != rule.Name)
            {
                oldRule.Name = rule.Name;
            }
            if (oldRule.Explanation != rule.Explanation)
            {
                oldRule.Explanation = rule.Explanation;
            }
            if (oldRule.TranslatedExplanation != rule.TranslatedExplanation)
            {
                oldRule.TranslatedExplanation = rule.TranslatedExplanation;
            }

            try
            {
                _context.Rules.Update(oldRule);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return rule;
        }

        public async Task<DbVocabularyExercise> EditVocabularyExerciseAsync(DbVocabularyExercise vocabularyExercise)
        {
            var oldExercise = await _context.VocabularyExercises
                .Where(e => e.Id == vocabularyExercise.Id)
                .SingleOrDefaultAsync();

            if (oldExercise == null)
            {
                return null;
            }

            if (oldExercise.Sentence != vocabularyExercise.Sentence)
            {
                oldExercise.Sentence = vocabularyExercise.Sentence;
            }
            if (oldExercise.TranslatedSentence != vocabularyExercise.TranslatedSentence)
            {
                oldExercise.TranslatedSentence = vocabularyExercise.TranslatedSentence;
            }
            if (oldExercise.CorrectAnswer != vocabularyExercise.CorrectAnswer)
            {
                oldExercise.CorrectAnswer = vocabularyExercise.CorrectAnswer;
            }
            if (oldExercise.TranslatedCorrectAnswer != vocabularyExercise.TranslatedCorrectAnswer)
            {
                oldExercise.TranslatedCorrectAnswer = vocabularyExercise.TranslatedCorrectAnswer;
            }
            if (oldExercise.Picture != vocabularyExercise.Picture)
            {
                oldExercise.Picture = vocabularyExercise.Picture;
            }
            if (oldExercise.WrongAnswer1 != vocabularyExercise.WrongAnswer1)
            {
                oldExercise.WrongAnswer1 = vocabularyExercise.WrongAnswer1;
            }
            if (oldExercise.WrongAnswer2 != vocabularyExercise.WrongAnswer2)
            {
                oldExercise.WrongAnswer2 = vocabularyExercise.WrongAnswer2;
            }
            if (oldExercise.WrongAnswer3 != vocabularyExercise.WrongAnswer3)
            {
                oldExercise.WrongAnswer3 = vocabularyExercise.WrongAnswer3;
            }
            if (oldExercise.TranslatedWrongAnswer1 != vocabularyExercise.TranslatedWrongAnswer1)
            {
                oldExercise.TranslatedWrongAnswer1 = vocabularyExercise.TranslatedWrongAnswer1;
            }
            if (oldExercise.TranslatedWrongAnswer2 != vocabularyExercise.TranslatedWrongAnswer2)
            {
                oldExercise.TranslatedWrongAnswer2 = vocabularyExercise.TranslatedWrongAnswer2;
            }
            if (oldExercise.TranslatedWrongAnswer3 != vocabularyExercise.TranslatedWrongAnswer3)
            {
                oldExercise.TranslatedWrongAnswer3 = vocabularyExercise.TranslatedWrongAnswer3;
            }

            try
            {
                _context.VocabularyExercises.Update(oldExercise);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return vocabularyExercise;
        }

        public async Task<ICollection<DbGrammarExercise>> GetGrammarExercisesByTestIdAsync(int testId)
        {
            return await _context.GrammarExercises
                .Include(e => e.Test)
                .Where(t => t.TestId == testId)
                .ToListAsync();
        }

        public async Task<ICollection<DbRule>> GetGrammarRulesByTestIdAsync(int testId)
        {
            return await _context.GrammarExercises
                .Include(e => e.Rule)
                .Where(e => e.TestId == testId)
                .Select(e => e.Rule)
                .Distinct()
                .ToListAsync();
        }

        public async Task<ICollection<DbVocabularyExercise>> GetVocabularyExercisesByTestIdAsync(int id)
        {
            return await _context.VocabularyExercises
                .Include(e => e.Test)
                .Where(t => t.TestId == id)
                .ToListAsync();
        }
    }
}
