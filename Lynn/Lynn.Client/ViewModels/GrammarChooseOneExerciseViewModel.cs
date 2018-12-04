using Lynn.Client.Enums;
using Lynn.Client.Helpers;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class GrammarChooseOneExerciseViewModel : ChoosingExerciseBaseViewModel
    {
        public List<string> Answers { get; set; }
        public ICommand Answer_Click { get; set; }
        public bool IsCorrect { get; set; }
        public ICommand NextCommand { get; set; }

        private GrammarExercise _exercise;
        public GrammarExercise Exercise
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

        public GrammarChooseOneExerciseViewModel(GrammarExercise grammarExercise, ICommand nextCommand)
        {
            Exercise = grammarExercise;
            NextCommand = nextCommand;
            Answers = new List<string>();
            SetAnswersRandom(Answers, Exercise);
            Answer_Click = new RelayCommand<string>(CheckAnswer);
        }

        private void CheckAnswer(string userAnswer)
        {
            if (userAnswer == Exercise.CorrectAnswer)
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

    }
}
