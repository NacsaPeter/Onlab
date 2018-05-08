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
    public class PictureExerciseViewModel : ViewModelBase
    {
        public ContentDialog ResultContentDialog { get; private set; }
        public bool IsCorrect { get; private set; }
        public string PictureLocation { get; private set; }

        private List<string> _answers;
        public string AnswerOne
        {
            get { return _answers[0]; }
            set { _answers[0] = value; }
        }
        public string AnswerTwo
        {
            get { return _answers[1]; }
            set { _answers[1] = value; }
        }
        public string AnswerThree
        {
            get { return _answers[2]; }
            set { _answers[2] = value; }
        }
        public string AnswerFour
        {
            get { return _answers[3]; }
            set { _answers[3] = value; }
        }

        public ICommand AnswerOne_Click { get; set; }
        public ICommand AnswerTwo_Click { get; set; }
        public ICommand AnswerThree_Click { get; set; }
        public ICommand AnswerFour_Click { get; set; }

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

        public PictureExerciseViewModel(VocabularyExercise vocabularyExercise)
        {
            Exercise = vocabularyExercise;
            SetAnswersRandom();
            PictureLocation = $"/Assets/{Exercise.Picture}";
            ResultContentDialog = new ContentDialog { CloseButtonText = "Tovább" };
            AnswerOne_Click = new RelayCommand(new Action(CheckAnswerOne));
            AnswerTwo_Click = new RelayCommand(new Action(CheckAnswerTwo));
            AnswerThree_Click = new RelayCommand(new Action(CheckAnswerThree));
            AnswerFour_Click = new RelayCommand(new Action(CheckAnswerFour));
        }

        private void CheckAnswerOne() => CheckAnswer(0);
        private void CheckAnswerTwo() => CheckAnswer(1);
        private void CheckAnswerThree() => CheckAnswer(2);
        private void CheckAnswerFour() => CheckAnswer(3);

        private void CheckAnswer(int chosen)
        {
            TextBlock text = new TextBlock
            {
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold
            };
            if (Exercise.Expression == _answers[chosen])
            {
                IsCorrect = true;
                text.Text = "A válasz helyes.";
                ResultContentDialog.Content = text;
                ResultContentDialog.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                IsCorrect = false;
                text.Text = $"A helyes válasz: { Exercise.Expression }";
                text.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                ResultContentDialog.Content = text;
                ResultContentDialog.Background = new SolidColorBrush(Colors.Red);
            }
            ResultContentDialog.ShowAsync();
        }

        private void SetAnswersRandom()
        {
            _answers = new List<string>();
            _answers.Add(Exercise.Expression);
            _answers.Add(Exercise.WrongAnswer1);
            _answers.Add(Exercise.WrongAnswer2);
            _answers.Add(Exercise.WrongAnswer3);

            Random random = new Random();
            int n = _answers.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = _answers[k];
                _answers[k] = _answers[n];
                _answers[n] = value;
            }
        }
    }
}
