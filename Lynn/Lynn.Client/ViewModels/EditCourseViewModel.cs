﻿using Lynn.Client.Helpers;
using Lynn.Client.Models;
using Lynn.Client.Services;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Lynn.Client.ViewModels
{
    public class EditCourseViewModel : Observable
    {
        public User LoggedInUser { get; set; }
        public ICommand SaveCourse_Click { get; set; }
        public ICommand DeleteCourse_Click { get; set; }
        public ObservableCollection<Language> Languages { get; set; }
        public ObservableCollection<Territory> Territories { get; set; }
        public ObservableCollection<CourseLevelDto> Levels { get; set; }

        private bool _saving = false;
        public bool Saving
        {
            get { return _saving; }
            set { Set(ref _saving, value, nameof(Saving)); }
        }

        private bool _saved = false;
        public bool Saved
        {
            get { return _saved; }
            set { Set(ref _saved, value, nameof(Saved)); }
        }

        private bool _notSaved = false;
        public bool NotSaved
        {
            get { return _notSaved; }
            set { Set(ref _notSaved, value, nameof(NotSaved)); }
        }

        private Course _course;
        public Course Course
        {
            get { return _course; }
            set { Set(ref _course, value, nameof(Course)); }
        }

        private ObservableCollection<TestPresenter> _tests;
        public ObservableCollection<TestPresenter> Tests
        {
            get { return _tests; }
            set { Set(ref _tests, value, nameof(Tests)); }
        }

        private ObservableCollection<string> _languageNames;
        public ObservableCollection<string> LanguageNames
        {
            get { return _languageNames; }
            set { Set(ref _languageNames, value, nameof(LanguageNames)); }
        }
        private string _currentLearningLanguage;
        public string CurrentLearningLanguage
        {
            get { return _currentLearningLanguage; }
            set
            {
                Course.LearningLanguage.Language = Languages
                    .Where(l => l.Name == value)
                    .SingleOrDefault();
                Set(ref _currentLearningLanguage, value, nameof(CurrentLearningLanguage));
            }
        }
        private string _currentTeachingLanguage;
        public string CurrentTeachingLanguage
        {
            get { return _currentTeachingLanguage; }
            set
            {
                Course.TeachingLanguage.Language = Languages
                    .Where(l => l.Name == value)
                    .SingleOrDefault();
                Set(ref _currentTeachingLanguage, value, nameof(CurrentTeachingLanguage));
            }
        }

        private ObservableCollection<string> _territoryNames;
        public ObservableCollection<string> TerritoryNames
        {
            get { return _territoryNames; }
            set { Set(ref _territoryNames, value, nameof(TerritoryNames)); }
        }
        private string _currentLearningTerritory;
        public string CurrentLearningTerritory
        {
            get { return _currentLearningTerritory; }
            set
            {
                Course.LearningLanguage.Territory = Territories
                    .Where(l => l.Name == value)
                    .SingleOrDefault();
                Set(ref _currentLearningTerritory, value, nameof(CurrentLearningTerritory));
            }
        }
        private string _currentTeachingTerritory;
        public string CurrentTeachingTerritory
        {
            get { return _currentTeachingTerritory; }
            set
            {
                Course.TeachingLanguage.Territory = Territories
                    .Where(l => l.Name == value)
                    .SingleOrDefault();
                Set(ref _currentTeachingTerritory, value, nameof(CurrentTeachingTerritory));
            }
        }

        private ObservableCollection<string> _levelCodes;
        public ObservableCollection<string> LevelCodes
        {
            get { return _levelCodes; }
            set { Set(ref _levelCodes, value, nameof(LevelCodes)); }
        }
        private string _currentLevelCode;
        public string CurrentLevelCode
        {
            get { return _currentLevelCode; }
            set
            {
                Course.Level = Levels
                    .Where(l => l.LevelCode == value)
                    .SingleOrDefault();
                Set(ref _currentLevelCode, value, nameof(CurrentLevelCode));
            }
        }

        public EditCourseViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
            SaveCourse_Click = new RelayCommand(SaveCourse);
            DeleteCourse_Click = new RelayCommand(DeleteCourseContentDialog);
        }

        public async Task SetLanguages()
        {
            var service = new LanguageService();
            Languages = await service.GetLanguages();
            LanguageNames = new ObservableCollection<string>();
            foreach (var language in Languages)
            {
                LanguageNames.Add(language.Name);
            }
            Territories = await service.GetTerritories();
            TerritoryNames = new ObservableCollection<string>();
            foreach (var territory in Territories)
            {
                TerritoryNames.Add(territory.Name);
            }
            Levels = await service.GetCourseLevels();
            LevelCodes = new ObservableCollection<string>();
            foreach (var level in Levels)
            {
                LevelCodes.Add(level.LevelCode);
            }
        }

        public async Task ProcessTestsByCourseId(int courseId)
        {
            var service = new TestService();
            var result = await service.GetTestsByCourseId(courseId);
            Tests = TestPresenter.GetTestPresenters(result);
            Tests.Add(new NewTestPresenter());
        }

        private async void SaveCourse()
        {
            Course.Editor = LoggedInUser.Username;
            var service = new CourseService();
            if (Course.Id == 0)
            {
                Saving = true;
                var course = await service.PostCourseAsync(Course);
                Saving = false;
                if (course == null)
                {
                    NotSaved = true;
                    await Task.Delay(2000);
                    NotSaved = false;
                }
                else
                {
                    Course = course;    
                    Tests = new ObservableCollection<TestPresenter>
                    {
                        new NewTestPresenter()
                    };
                    Saved = true;
                    await Task.Delay(2000);
                    Saved = false;
                }
            }
            else
            {
                Saving = true;
                var course = await service.PutCourseAsync(Course);
                Saving = false;
                if (course == null)
                {
                    NotSaved = true;
                    await Task.Delay(2000);
                    NotSaved = false;
                }
                else
                {
                    Course = course;
                    Saved = true;
                    await Task.Delay(2000);
                    Saved = false;
                }
            }
        }

        private async void DeleteCourseContentDialog()
        {
            var contentDialog = new ContentDialog
            {
                Content = new TextBlock
                {
                    Text = $"Biztosan törli a(z) {Course.CourseName} kurzust?",
                    TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap,
                    FontSize = 18,
                    Margin = new Windows.UI.Xaml.Thickness(20)
                },
                Background = new SolidColorBrush(Colors.LemonChiffon),
                CloseButtonText = "Mégse",
                PrimaryButtonText = "Törlés",
                PrimaryButtonCommand = new RelayCommand(DeleteCourse)
            };
            await contentDialog.ShowAsync();
        }

        private async void DeleteCourse()
        {
            var service = new CourseService();
            bool result = await service.DeleteCourseAsync(Course);
            if (result)
            {
                NavigationService.GoBack();
            }
        }
    }
}
