using Lynn.Client.Helpers;
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

        public DoExercisesViewModel(Grid page)
        {
            _page = page;
            _correctAnswers = 0;

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

        private Grid _page;
        private ObservableCollection<VocabularyExercise> _vocabularyExercises;
        private int _correctAnswers;

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
            _page.Children.Clear();
            if (_vocabularyExercises.Count != 0)
            {
                var exercise = _vocabularyExercises[0];
                var exerciseView = new ChooseOneExerciseView(exercise);
                exerciseView.ViewModel.ResultContentDialog.CloseButtonClick += NextExercise;
                _page.Children.Add(exerciseView);
                _vocabularyExercises.RemoveAt(0);
            }

            return searchedExercises;
        }

        private void NextExercise(object sender, ContentDialogButtonClickEventArgs args)
        {
            if (((ChooseOneExerciseView)_page.Children[0]).ViewModel.IsCorrect) _correctAnswers++;
            _page.Children.Clear();
            if (_vocabularyExercises.Count != 0)
            { 
                var exercise = _vocabularyExercises[0];
                var exerciseView = new ChooseOneExerciseView(exercise);
                exerciseView.ViewModel.ResultContentDialog.CloseButtonClick += NextExercise;
                _page.Children.Add(exerciseView);
                _vocabularyExercises.RemoveAt(0);
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
                TextBlock pointsTextBlock = new TextBlock
                {
                    Text = $"Pontszáma: {(int)((float)_correctAnswers / (float)Test.NumberOfQuestions * (float)Test.MaxPoints)}/{Test.MaxPoints}",
                    FontSize = 24,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                stackPanel.Children.Add(endTextBlock);
                stackPanel.Children.Add(pointsTextBlock);
                _page.Children.Add(stackPanel);
            }
        }
    }
}
