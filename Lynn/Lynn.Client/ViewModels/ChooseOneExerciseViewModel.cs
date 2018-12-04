using Lynn.Client.Enums;
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
        public bool IsCorrect { get; set; }
        private bool _isKnownToLearnig;
        public ICommand NextCommand { get; set; }
        public List<string> Answers { get; set; }
        public ICommand Answer_Click { get; set; }

        private VocabularyExercise _exercise;
        public VocabularyExercise Exercise
        {
            get { return _exercise; }
            set { Set(ref _exercise, value, nameof(Exercise)); }
        }

        private ExerciseState _state;
        public ExerciseState State
        {
            get { return _state; }
            set { Set(ref _state, value, nameof(State)); }
        }

        private string _translatedExpression;
        public string TranslatedExpression
        {
            get { return _translatedExpression; }
            set { Set(ref _translatedExpression, value, nameof(TranslatedExpression)); }
        }


        public ChooseOneExerciseViewModel(VocabularyExercise vocabularyExercise, ICommand nextCommand)
        {
            Exercise = vocabularyExercise;
            NextCommand = nextCommand;
            State = ExerciseState.NotAnswered;
            SetExerciseType();
            Answers = new List<string>();
            SetAnswersRandom(Answers, Exercise, TranslatedExpression, _isKnownToLearnig);
            Answer_Click = new RelayCommand<string>(CheckAnswer);
        }

        private void CheckAnswer(string userAnswer)
        {
            if (userAnswer == TranslatedExpression)
            {
                IsCorrect = true;
                State = ExerciseState.Success;
            }
            else
            {
                IsCorrect = false;
                State = ExerciseState.Fail;
            }
        }

        private void SetExerciseType()
        {
            Random random = new Random();
            int randomNumber = random.Next(2);
            _isKnownToLearnig = (randomNumber == 0) ? true : false;
            Expression = _isKnownToLearnig ? Exercise.TranslatedCorrectAnswer : Exercise.CorrectAnswer;
            _translatedExpression = _isKnownToLearnig ? Exercise.CorrectAnswer : Exercise.TranslatedCorrectAnswer;
        }
    }
}
