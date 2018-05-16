using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Models
{
    public class VocabularyExercisePresenter
    {
        private VocabularyExercise _exercise;
        public VocabularyExercise Exercise { get { return _exercise; } }
        public string Expression { get { return _exercise.Expression; } }
        public string TranslatedExpression { get { return _exercise.TranslatedExpression; } }
        public string Sentence { get { return _exercise.Sentence; } }
        public string TranslatedSentence { get { return _exercise.TranslatedSentence; } }
        public string Picture { get { return $"/Assets/{_exercise.Expression}.jpg"; } }

        public VocabularyExercisePresenter(VocabularyExercise exercise)
        {
            _exercise = exercise;
        }

        public static ObservableCollection<VocabularyExercisePresenter> GetVocabularyExercisePresenters(ObservableCollection<VocabularyExercise> exercises)
        {
            var presenters = new ObservableCollection<VocabularyExercisePresenter>();
            foreach (var item in exercises)
            {
                presenters.Add(new VocabularyExercisePresenter(item));
            }
            return presenters;
        }
    }
}
