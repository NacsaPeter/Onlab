using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynn.DTO;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Lynn.Client.ViewModels
{
    public class TranslationExerciseViewModel : ViewModelBase
    {
        private bool _isKnownToLearning;
        public string Sentence { get; set; }
        public string TranslatedSentence { get; set; }
        public ContentDialog ResultContentDialog { get; private set; }
        public bool IsCorrect { get; private set; }

        private string _translation;
        public string Translation
        {
            get { return _translation; }
            set
            {
                if (_translation != value)
                {
                    _translation = value;
                    RaisePropertyChanged(nameof(Translation));
                }
            }
        }

        private VocabularyExercise _exercise;
        public VocabularyExercise Exercise
        {
            get { return _exercise; }
            set
            {
                if (_exercise != value)
                {
                    _exercise = value;
                    RaisePropertyChanged(nameof(Exercise));
                }
            }
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

        public void CheckAnswer()
        {
            TextBlock text = new TextBlock
            {
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold
            };
            if (Translation == TranslatedSentence)
            {
                IsCorrect = true;
                text.Text = "A válasz helyes.";
                ResultContentDialog.Content = text;
                ResultContentDialog.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                IsCorrect = false;
                text.Text = $"A helyes válasz: { TranslatedSentence }";
                text.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                ResultContentDialog.Content = text;
                ResultContentDialog.Background = new SolidColorBrush(Colors.Red);
            }
            ResultContentDialog.ShowAsync();
        }
    }
}
