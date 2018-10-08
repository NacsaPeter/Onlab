using Lynn.Client.Helpers;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.ViewModels
{
    public abstract class ChoosingExerciseBaseViewModel : ExerciseBaseViewModel
    {
        protected void SetAnswersRandom(List<string> answers, VocabularyExercise exercise, string translatedExpression, bool isKnownToLearnig)
        {
            answers.Add(translatedExpression);
            answers.Add(isKnownToLearnig ? exercise.WrongAnswer1 : exercise.TranslatedWrongAnswer1);
            answers.Add(isKnownToLearnig ? exercise.WrongAnswer2 : exercise.TranslatedWrongAnswer2);
            answers.Add(isKnownToLearnig ? exercise.WrongAnswer3 : exercise.TranslatedWrongAnswer3);

            Random random = new Random();
            int n = answers.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = answers[k];
                answers[k] = answers[n];
                answers[n] = value;
            }
        }
    }
}
