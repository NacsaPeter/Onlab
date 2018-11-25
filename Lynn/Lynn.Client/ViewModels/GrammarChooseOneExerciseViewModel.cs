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
        public ContentDialog ResultContentDialog { get; private set; }

        private bool _isCorrect;
        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }

        private GrammarExercise _exercise;
        public GrammarExercise Exercise
        {
            get { return _exercise; }
            set { Set(ref _exercise, value, nameof(Exercise)); }
        }

        public GrammarChooseOneExerciseViewModel(GrammarExercise grammarExercise)
        {
            Exercise = grammarExercise;
            Answers = new List<string>();
            SetAnswersRandom(Answers, Exercise);
            ResultContentDialog = new ContentDialog { CloseButtonText = "Tovább" };
            Answer_Click = new RelayCommand<string>(CheckAnswer);
        }

        private void CheckAnswer(string chosen) =>
            CheckAnswer(ResultContentDialog, Exercise.CorrectAnswer, chosen, ref _isCorrect);

    }
}
