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
            LoggedInUser = MainViewModel.LoggedInUser;
        }

        private CoursePresenter _course;
        public CoursePresenter Course
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

        private Enrollment _enrollment;
        public Enrollment Enrollment
        {
            get { return _enrollment; }
            set { Set(ref _enrollment, value, nameof(Enrollment)); }
        }

        private ObservableCollection<TestPresenter> _tests;
        public ObservableCollection<TestPresenter> Tests
        {
            get { return _tests; }
            set { Set(ref _tests, value, nameof(Tests)); }
        }

        public async void RefreshTests()
        {
            await ProcessEnrollment(LoggedInUser.ID, Course.Id);
            await ProcessTestsByCourseId(Course.Id);

        }

        private async Task ProcessTestsByCourseId(int courseId)
        {
            var service = new TestService();
            var result = await service.GetTestsByCourseId(courseId);
            Tests = TestPresenter.GetTestPresenters(result, Enrollment.Level);
        }

        private async Task ProcessEnrollment(int userId, int courseId)
        {
            var service = new EnrollmentService();
            Enrollment = await service.GetEnrollment(userId, courseId);
        }

        public void StartTest(Test test)
        {
            NavigationService.Navigate(typeof(DetailedTestPage), test);
        }
    }
}
