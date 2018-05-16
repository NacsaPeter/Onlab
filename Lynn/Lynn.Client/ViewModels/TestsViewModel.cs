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
    public class TestsViewModel : Observable
    {
        public TestsViewModel()
        {
            LoggedInUser = new User { ID = 6, Username = "TestUser15", Email = "testuser@lynn.com", PasswordHash = "lukztthrgh34hb", Points = 24 };
        }

        private Course _course;
        public Course Course
        {
            get { return _course; }
            set { Set(ref _course, value, nameof(Course)); }
        }

        private User _loggedInUser;
        public User LoggedInUser
        {
            get { return _loggedInUser; }
            set { Set(ref _loggedInUser, value, nameof(LoggedInUser)); }
        }

        private ObservableCollection<TestPresenter> _tests;
        public ObservableCollection<TestPresenter> Tests
        {
            get { return _tests; }
            set { Set(ref _tests, value, nameof(Tests)); }
        }

        public void RefreshTests()
        {
            ProcessTestsByCourseID(Course.ID);
        }

        private async Task ProcessTestsByCourseID(int courseID)
        {
            var service = new CourseService();
            var result = await service.GetTestsByCourseID(courseID);
            Tests = TestPresenter.GetTestPresenters(result);
        }

        public void StartTest(Test test)
        {
            NavigationService.Navigate(typeof(DoExercisesPage), test);
        }
    }
}
