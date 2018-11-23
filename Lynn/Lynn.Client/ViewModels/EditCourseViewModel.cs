using Lynn.Client.Helpers;
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

namespace Lynn.Client.ViewModels
{
    public class EditCourseViewModel : Observable
    {
        public User LoggedInUser { get; set; }
        public ICommand SaveCourse_Click { get; set; }

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

        private ObservableCollection<Language> _languages;
        public ObservableCollection<Language> Languages
        {
            get { return _languages; }
            set { Set(ref _languages, value, nameof(Languages)); }
        }

        private ObservableCollection<Territory> _territories;
        public ObservableCollection<Territory> Territories
        {
            get { return _territories; }
            set { Set(ref _territories, value, nameof(Territories)); }
        }

        private ObservableCollection<CourseLevelDto> _levels;
        public ObservableCollection<CourseLevelDto> Levels
        {
            get { return _levels; }
            set { Set(ref _levels, value, nameof(Levels)); }
        }

        public EditCourseViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
            SaveCourse_Click = new RelayCommand(SaveCourse);
            SetLanguages();
        }

        private async Task SetLanguages()
        {
            var service = new LanguageService();
            Languages = await service.GetLanguages();
            Territories = await service.GetTerritories();
            Levels = await service.GetCourseLevels();
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
            var course = Course;
            course.Id = -1;
        }
    }
}
