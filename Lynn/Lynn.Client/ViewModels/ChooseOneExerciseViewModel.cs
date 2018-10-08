using Lynn.Client.Helpers;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Lynn.Client.ViewModels
{
    public class ChooseOneExerciseViewModel : ChoosingExerciseBaseViewModel
    {
        public string Expression { get; private set; }
        public ContentDialog ResultContentDialog { get; private set; }

        private bool _isCorrect;
        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }

        private string _translatedExpression;
        private bool _isKnownToLearnig;

        public List<string> Answers { get; set; }
        public ICommand Answer_Click { get; set; }

        private VocabularyExercise _exercise;
        public VocabularyExercise Exercise
        {
            get { return _exercise; }
            set { Set(ref _exercise, value, nameof(Exercise)); }
        }

        public ChooseOneExerciseViewModel(VocabularyExercise vocabularyExercise)
        {
            Exercise = vocabularyExercise;
            SetExerciseType();
            Answers = new List<string>();
            SetAnswersRandom(Answers, Exercise, _translatedExpression, _isKnownToLearnig);
            ResultContentDialog = new ContentDialog { CloseButtonText = "Tovább" };
            Answer_Click = new RelayCommand<string>(CheckAnswer);
        }

        private void CheckAnswer(string chosen) =>
            CheckAnswer(ResultContentDialog, _translatedExpression, chosen, ref _isCorrect);

        private void SetExerciseType()
        {
            Random random = new Random();
            int randomNumber = random.Next(2);
            _isKnownToLearnig = (randomNumber == 0) ? true : false;
            Expression = _isKnownToLearnig ? Exercise.TranslatedExpression : Exercise.Expression;
            _translatedExpression = _isKnownToLearnig ? Exercise.Expression : Exercise.TranslatedExpression;
        }
    }
}
