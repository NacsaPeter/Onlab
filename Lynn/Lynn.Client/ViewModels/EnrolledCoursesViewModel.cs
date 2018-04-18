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
    public class EnrolledCoursesViewModel : ViewModelBase
    {
        private readonly HttpClient client = new HttpClient();

        private VariableSizedWrapGrid _coursesContainer;

        public EnrolledCoursesViewModel(VariableSizedWrapGrid coursesContainer)
        {
            _coursesContainer = coursesContainer;

            client.BaseAddress = new Uri("http://localhost:56750/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrolledcourses"));

            RefreshEnrolledCourses();
        }

        private void RefreshEnrolledCourses()
        {
            _coursesContainer.Children.Clear();
            User loggedInUser = new User { ID = 6, Username = "TestUser15", Email = "testuser@lynn.com", PasswordHash = "lukztthrgh34hb", Points = 0 };
            var result = ProcessEnrolledCourses(loggedInUser);
        }

        private async Task<ObservableCollection<Course>> ProcessEnrolledCourses(User user)
        {
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));

            var streamTask = client.GetStreamAsync($"http://localhost:56750/api/enrolledcourses/{user.ID}");
            var searchedCourses = serializer.ReadObject(await streamTask) as ObservableCollection<Course>;

            foreach (var course in searchedCourses)
            {
                _coursesContainer.Children.Add(new CourseToStartView(course));
            }
            return searchedCourses;
        }
    }
}
