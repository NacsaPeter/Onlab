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
        public DoExercisesViewModel(Grid gridOfTest)
        {
            _gridOfTest = gridOfTest;
            LoggedInUser = MainViewModel.LoggedInUser;
            Results = new ObservableCollection<ResultPresenter>();
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

        private bool _end;
        public bool End
        {
            get { return _end; }
            set { Set(ref _end, value, nameof(End)); }
        }

        private int _points;
        public int Points
        {
            get { return _points; }
            set { Set(ref _points, value, nameof(Points)); }
        }

        private int _correctAnswers = 0;
        public int CorrectAnswers
        {
            get { return _correctAnswers; }
            set { Set(ref _correctAnswers, value, nameof(CorrectAnswers)); }
        }

        private ObservableCollection<ResultPresenter> _results;
        public ObservableCollection<ResultPresenter> Results
        {
            get { return _results; }
            set { Set(ref _results, value, nameof(Results)); }
        }

        private Grid _gridOfTest;
        private int _currentExerciseNum = 0;

        public void DoExercises()
        {
            if (VocabularyExercises.Count != _currentExerciseNum)
            {
                var exercise = VocabularyExercises[_currentExerciseNum];
                IExerciseView exerciseView = SetExerciseType(exercise.Exercise);
                exerciseView.GetResultContentDialog().CloseButtonClick += NextExercise;
                _gridOfTest.Children.Add(exerciseView.GetUIElement());
                _currentExerciseNum++;
            }
        }

        public async Task ProcessExercisesAsync()
        {
            var service = new ExerciseService();
            var result = await service.GetVocabularyExercises(Test);
            VocabularyExercises = VocabularyExercisePresenter.GetVocabularyExercisePresenters(result);
            if (VocabularyExercises.Count != 0)
            {
                CurrentExercise = VocabularyExercises[0];
            }
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

        private async void NextExercise(object sender, ContentDialogButtonClickEventArgs args)
        {
            var result = new ResultPresenter
            {
                Number = Results.Count + 1,
                IsCorrect = false
            };

            if (((IExerciseView)_gridOfTest.Children[0]).CheckIsCorrect())
            {
                CorrectAnswers++;
                result.IsCorrect = true;
            }

            Results.Add(result);
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
                Points = (int)(CorrectAnswers / (float)Test.NumberOfQuestions * Test.MaxPoints);
                End = true;
                var service = new TestService();
                var testResult = new TestResultDto
                {
                    RightAnswers = CorrectAnswers,
                    WrongAnswers = Test.NumberOfQuestions - CorrectAnswers,
                    Points = Points
                };
                var userPoints = await service.PostTestResult(LoggedInUser, Test, testResult);
                LoggedInUser.Points = userPoints;
            }
        }
    }
}
