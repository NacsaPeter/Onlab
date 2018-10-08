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
using Windows.UI.Xaml.Media;

namespace Lynn.Client.ViewModels
{
    public class PictureExerciseViewModel : ChoosingExerciseBaseViewModel
    {
        public ContentDialog ResultContentDialog { get; private set; }       
        public string PictureLocation { get; private set; }

        private bool _isCorrect;
        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }

        public List<string> Answers { get; set; } 
        public ICommand Answer_Click { get; set; }

        private VocabularyExercise _exercise;
        public VocabularyExercise Exercise
        {
            get { return _exercise; }
            set { Set(ref _exercise, value, nameof(Exercise)); }
        }

        public PictureExerciseViewModel(VocabularyExercise vocabularyExercise)
        {
            Exercise = vocabularyExercise;
            Answers = new List<string>();
            SetAnswersRandom(Answers, Exercise, Exercise.Expression, true);
            PictureLocation = $"/Assets/{Exercise.Picture}";
            ResultContentDialog = new ContentDialog { CloseButtonText = "Tovább" };
            Answer_Click = new RelayCommand<string>(CheckAnswer);
        }

        private void CheckAnswer(string chosen) =>
            CheckAnswer(ResultContentDialog, Exercise.Expression, chosen, ref _isCorrect);

    }
}
