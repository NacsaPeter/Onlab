using Lynn.Client.Helpers;
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
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class EnrollInCourseViewModel : Observable
    {
        public ICommand SearchCourseByName_Click { get; set; }
        public ICommand SearchCourseByLanguage_Click { get; set; }

        private ObservableCollection<CoursePresenter> _courses;
        public ObservableCollection<CoursePresenter> Courses
        {
            get { return _courses;  }
            set { Set(ref _courses, value, nameof(Courses)); }
        }

        private ObservableCollection<Language> _languages;
        public ObservableCollection<Language> Languages
        {
            get { return _languages; }
            set { Set(ref _languages, value, nameof(Languages)); }
        }

        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set { Set(ref _courseName, value, nameof(CourseName)); }
        }

        private Language _knownLanguage;
        public Language KnownLanguage
        {
            get { return _knownLanguage; }
            set { Set(ref _knownLanguage, value, nameof(KnownLanguage)); }
        }

        private Language _learningLanguage;
        public Language LearningLanguage
        {
            get { return _learningLanguage; }
            set { Set(ref _learningLanguage, value, nameof(LearningLanguage)); }
        }

        public EnrollInCourseViewModel()
        {
            SetLanguages();
            SearchCourseByLanguage_Click = new RelayCommand(new Action(SearchCourseByLanguage));
            SearchCourseByName_Click = new RelayCommand(new Action(SearchCourseByName));           
        }

        private async Task SetLanguages()
        {
            var service = new LanguageService();
            Languages = await service.GetLanguages();
        }

        private async void SearchCourseByName()
        {
            var service = new CourseService();
            var results = await service.GetCoursesByNameAsync(CourseName);
            Courses = CoursePresenter.GetCoursePresenters(results);
        }

        private async void SearchCourseByLanguage()
        {
            var service = new LanguageService();
            var results = await service.GetCoursesByLanguageCode(KnownLanguage.Code, LearningLanguage.Code);
            Courses = CoursePresenter.GetCoursePresenters(results);
        }

        public async Task ShowCourseDetails(Course course)
        {
            var detailedCourse = new DetailedCourseToEnrollInView(course);
            await detailedCourse.ShowAsync();
        }
    }
}
