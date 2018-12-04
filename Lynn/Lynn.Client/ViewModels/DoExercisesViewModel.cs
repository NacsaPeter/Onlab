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

        private ObservableCollection<VocabularyExercise> _vocabularyExercises;
        public ObservableCollection<VocabularyExercise> VocabularyExercises
        {
            get { return _vocabularyExercises; }
            set { Set(ref _vocabularyExercises, value, nameof(VocabularyExercises)); }
        }

        private ObservableCollection<GrammarExercise> _grammarExercises;
        public ObservableCollection<GrammarExercise> GrammarExercises
        {
            get { return _grammarExercises; }
            set { Set(ref _grammarExercises, value, nameof(GrammarExercises)); }
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
            if (Test.CategoryName == "Nyelvtan")
            {
                if (GrammarExercises.Count != _currentExerciseNum)
                {
                    IExerciseView exerciseView = new GrammarChooseOneExerciseView(
                        GrammarExercises[_currentExerciseNum], new RelayCommand(NextExercise)
                      );
                    _gridOfTest.Children.Add(exerciseView.GetUIElement());
                    _currentExerciseNum++;
                }
            }
            else
            {
                if (VocabularyExercises.Count != _currentExerciseNum)
                {
                    var exercise = VocabularyExercises[_currentExerciseNum];
                    IExerciseView exerciseView = SetExerciseType(exercise);
                    _gridOfTest.Children.Add(exerciseView.GetUIElement());
                    _currentExerciseNum++;
                }
            }
        }

        public async Task ProcessExercisesAsync()
        {
            var service = new ExerciseService();
            if (Test.CategoryName == "Nyelvtan")
            {
                GrammarExercises = await service.GetGrammarExercises(Test);
            }
            else
            {
                VocabularyExercises = await service.GetVocabularyExercises(Test);
            }
        }

        private IExerciseView SetExerciseType(VocabularyExercise exercise)
        {
            Random random = new Random();
            int randomNumber = random.Next(3);
            var nextCommand = new RelayCommand(NextExercise);
            if (randomNumber == 0)
            {
                return new ChooseOneExerciseView(exercise, nextCommand);
            }
            else if (randomNumber == 1)
            {
                return new PictureExerciseView(exercise, nextCommand);
            }
            else
            {
                return new TranslationExerciseView(exercise, nextCommand);
            }              
        }

        private async void NextExercise()
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

            if (Test.CategoryName == "Nyelvtan")
            {
                if (GrammarExercises.Count != _currentExerciseNum)
                {
                    IExerciseView exerciseView = new GrammarChooseOneExerciseView(
                        GrammarExercises[_currentExerciseNum], new RelayCommand(NextExercise)
                      );
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
            else
            {
                if (VocabularyExercises.Count != _currentExerciseNum)
                {
                    var exercise = VocabularyExercises[_currentExerciseNum];
                    IExerciseView exerciseView = SetExerciseType(exercise);
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
}
