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

        private ObservableCollection<CoursePresenter> _courses;
        public ObservableCollection<CoursePresenter> Courses
        {
            get { return _courses;  }
            set { Set(ref _courses, value, nameof(Courses)); }
        }

        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set { Set(ref _courseName, value, nameof(CourseName)); }
        }

        public EnrollInCourseViewModel()
        {
            SearchCourseByName_Click = new RelayCommand(new Action(SearchCourseByName));
        }

        private void SearchCourseByName()
        {
            ProcessCoursesByName(CourseName);
        }

        private async Task ProcessCoursesByName(string name)
        {
            var service = new EnrollmentService();
            var results = await service.GetCoursesByNameAsync(name);
            Courses = CoursePresenter.GetCoursePresenters(results);
        }

        public void ShowCourseDetails(Course course)
        {
            DetailedCourseToEnrollInView detailedCourse = new DetailedCourseToEnrollInView(course);
            detailedCourse.ShowAsync();
        }
    }
}
