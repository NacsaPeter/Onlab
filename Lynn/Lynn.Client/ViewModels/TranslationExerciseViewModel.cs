using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynn.Client.Helpers;
using Lynn.DTO;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Lynn.Client.ViewModels
{
    public class TranslationExerciseViewModel : ExerciseBaseViewModel
    {
        private bool _isKnownToLearning;
        public string Sentence { get; set; }
        public string TranslatedSentence { get; set; }
        public ContentDialog ResultContentDialog { get; private set; }

        private bool _isCorrect;
        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }

        private string _translation;
        public string Translation
        {
            get { return _translation; }
            set { Set(ref _translation, value, nameof(Translation)); }
        }

        private VocabularyExercise _exercise;
        public VocabularyExercise Exercise
        {
            get { return _exercise; }
            set { Set(ref _exercise, value, nameof(Exercise)); }
        }

        public TranslationExerciseViewModel(VocabularyExercise vocabularyExercise)
        {
            Exercise = vocabularyExercise;
            SetExerciseType();
            ResultContentDialog = new ContentDialog { CloseButtonText = "Tovább" };
        }

        private void SetExerciseType()
        {
            Random random = new Random();
            int randomNumber = random.Next(2);
            _isKnownToLearning = (randomNumber == 0) ? true : false;
            Sentence = _isKnownToLearning ? Exercise.TranslatedSentence : Exercise.Sentence;
            TranslatedSentence = _isKnownToLearning ? Exercise.Sentence : Exercise.TranslatedSentence;
        }

        public void CheckAnswer() =>
            CheckAnswer(ResultContentDialog, TranslatedSentence, Translation, ref _isCorrect);

    }
}
