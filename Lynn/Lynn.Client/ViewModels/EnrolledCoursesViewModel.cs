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
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class EnrolledCoursesViewModel : Observable
    {
        private ObservableCollection<Course> _courses;
        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set { Set(ref _courses, value, nameof(Courses)); }
        }

        public async Task RefreshEnrolledCourses(object sender, SelectionChangedEventArgs args)
        {
            User loggedInUser = MainViewModel.LoggedInUser;
            await ProcessEnrolledCourses(loggedInUser);
        }

        private async Task ProcessEnrolledCourses(User user)
        {
            var service = new CourseService();
            Courses = await service.GetEnrolledCourses(user);
        }

        public void StartCourse(Course course)
        {
            NavigationService.Navigate(typeof(TestsPage), course);
        }
    }
}
