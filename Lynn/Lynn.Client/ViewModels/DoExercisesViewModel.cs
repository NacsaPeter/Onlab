using Lynn.Client.Helpers;
using Lynn.Client.Interfaces;
using Lynn.Client.Views;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class DoExercisesViewModel : ViewModelBase
    {
        private readonly HttpClient client = new HttpClient();

        public ICommand Start_Click { get; set; }

        public DoExercisesViewModel(Grid gridOfTest)
        {
            _gridOfTest = gridOfTest;
            _correctAnswers = 0;
            _currentExercise = 0;

            client.BaseAddress = new Uri("http://localhost:56750/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercises"));         

            Start_Click = new RelayCommand(new Action(DoExercises));
        }

        private Test _test;
        public Test Test
        {
            get { return _test; }
            set
            {
                if (_test != value)
                {
                    _test = value;
                    RaisePropertyChanged(nameof(Test));
                }
            }
        }

        private Grid _gridOfTest;
        private ObservableCollection<VocabularyExercise> _vocabularyExercises;
        private int _currentExercise;
        private int _correctAnswers;
        public int Points { get; private set; }

        private void DoExercises()
        {
            var result = ProcessExercises(_test);          
        }

        private async Task<ObservableCollection<VocabularyExercise>> ProcessExercises(Test test)
        {
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<VocabularyExercise>));

            var streamTask = client.GetStreamAsync($"http://localhost:56750/api/exercises/{test.ID}");
            var searchedExercises = serializer.ReadObject(await streamTask) as ObservableCollection<VocabularyExercise>;

            _vocabularyExercises = searchedExercises;
            _gridOfTest.Children.Clear();
            if (_vocabularyExercises.Count != _currentExercise)
            {
                var exercise = _vocabularyExercises[_currentExercise];
                IExerciseView exerciseView = SetExerciseType(exercise);
                exerciseView.GetResultContentDialog().CloseButtonClick += NextExercise;
                _gridOfTest.Children.Add(exerciseView.GetUIElement());
                _currentExercise++;
            }

            return searchedExercises;
        }

        private IExerciseView SetExerciseType(VocabularyExercise exercise)
        {
            Random random = new Random();
            int randomNumber = random.Next(2);
            if (randomNumber == 0)
            {
                return new ChooseOneExerciseView(exercise);
            }
            else
            {
                return new TranslationExerciseView(exercise);
            }              
        }

        private void NextExercise(object sender, ContentDialogButtonClickEventArgs args)
        {
            if (((IExerciseView)_gridOfTest.Children[0]).CheckIsCorrect()) _correctAnswers++;
            _gridOfTest.Children.Clear();
            if (_vocabularyExercises.Count != _currentExercise)
            { 
                var exercise = _vocabularyExercises[_currentExercise];
                IExerciseView exerciseView = SetExerciseType(exercise);
                exerciseView.GetResultContentDialog().CloseButtonClick += NextExercise;
                _gridOfTest.Children.Add(exerciseView.GetUIElement());
                _currentExercise++;
            }
            else
            {
                StackPanel stackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                TextBlock endTextBlock = new TextBlock
                {
                    Text = "Vége",
                    FontSize = 50,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness { Bottom = 60 }
                };
                Points = (int)((float)_correctAnswers / (float)Test.NumberOfQuestions * (float)Test.MaxPoints);
                TextBlock pointsTextBlock = new TextBlock
                {
                    Text = $"Pontszáma: {Points}/{Test.MaxPoints}",
                    FontSize = 24,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                stackPanel.Children.Add(endTextBlock);
                stackPanel.Children.Add(pointsTextBlock);
                _gridOfTest.Children.Add(stackPanel);
            }
        }
    }
}
