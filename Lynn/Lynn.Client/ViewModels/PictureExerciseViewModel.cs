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
using Windows.UI.Xaml.Media;

namespace Lynn.Client.ViewModels
{
    public class PictureExerciseViewModel : ChoosingExerciseBaseViewModel
    { 
        public string PictureLocation { get; private set; }
        public bool IsCorrect { get; set; }
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

        public PictureExerciseViewModel(VocabularyExercise vocabularyExercise, ICommand nextCommand)
        {
            Exercise = vocabularyExercise;
            NextCommand = nextCommand;
            Answers = new List<string>();
            SetAnswersRandom(Answers, Exercise, Exercise.CorrectAnswer, true);
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            string baseurl = resourceLoader.GetString("BaseUri");
            PictureLocation = $"{baseurl}/api/pictures/{Exercise.Picture}";
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
