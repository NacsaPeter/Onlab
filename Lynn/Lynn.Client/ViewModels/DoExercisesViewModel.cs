using Lynn.Client.Helpers;
using Lynn.Client.Interfaces;
using Lynn.Client.Models;
using Lynn.Client.Services;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class DoExercisesViewModel : Observable
    {
        public ICommand Start_Click { get; set; }

        public DoExercisesViewModel(Grid gridOfTest)
        {
            _gridOfTest = gridOfTest;
            LoggedInUser = new User { ID = 6, Username = "TestUser15", Email = "testuser@lynn.com", PasswordHash = "lukztthrgh34hb", Points = 24 };
            Start_Click = new RelayCommand(new Action(DoExercises));
        }

        private Test _test;
        public Test Test
        {
            get { return _test; }
            set { Set(ref _test, value, nameof(Test)); }
        }

        private User _loggedInUser;
        public User LoggedInUser
        {
            get { return _loggedInUser; }
            set { Set(ref _loggedInUser, value, nameof(LoggedInUser)); }
        }

        private ObservableCollection<VocabularyExercisePresenter> _vocabularyExercises;
        public ObservableCollection<VocabularyExercisePresenter> VocabularyExercises
        {
            get { return _vocabularyExercises; }
            set { Set(ref _vocabularyExercises, value, nameof(VocabularyExercises)); }
        }

        private VocabularyExercisePresenter _currentExercise;
        public VocabularyExercisePresenter CurrentExercise
        {
            get { return _currentExercise; }
            set { Set(ref _currentExercise, value, nameof(CurrentExercise)); }
        }

        private Grid _gridOfTest;
        private int _currentExerciseNum = 0;
        private int _correctAnswers = 0;
        public int Points { get; private set; }

        private void DoExercises()
        {
            _gridOfTest.Children.Clear();
            _gridOfTest.RowDefinitions.Clear();
            _gridOfTest.ColumnDefinitions.Clear();
            if (VocabularyExercises.Count != _currentExerciseNum)
            {
                var exercise = VocabularyExercises[_currentExerciseNum];
                IExerciseView exerciseView = SetExerciseType(exercise.Exercise);
                exerciseView.GetResultContentDialog().CloseButtonClick += NextExercise;
                _gridOfTest.Children.Add(exerciseView.GetUIElement());
                _currentExerciseNum++;
            }
        }

        public void ProcessExercises()
        {
            ProcessExercisesAsync(Test);
        }

        private async Task ProcessExercisesAsync(Test test)
        {
            var service = new CourseService();
            var result = await service.GetVocabularyExercises(test);
            VocabularyExercises = VocabularyExercisePresenter.GetVocabularyExercisePresenters(result);
            CurrentExercise = VocabularyExercises[0];
        }

        private IExerciseView SetExerciseType(VocabularyExercise exercise)
        {
            Random random = new Random();
            int randomNumber = random.Next(3);
            if (randomNumber == 0)
            {
                return new ChooseOneExerciseView(exercise);
            }
            else if (randomNumber == 1)
            {
                return new PictureExerciseView(exercise);
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
            if (_vocabularyExercises.Count != _currentExerciseNum)
            { 
                var exercise = _vocabularyExercises[_currentExerciseNum];
                IExerciseView exerciseView = SetExerciseType(exercise.Exercise);
                exerciseView.GetResultContentDialog().CloseButtonClick += NextExercise;
                _gridOfTest.Children.Add(exerciseView.GetUIElement());
                _currentExerciseNum++;
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
