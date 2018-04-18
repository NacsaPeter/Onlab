using Lynn.Client.Helpers;
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
    public class EnrollInCourseViewModel : ViewModelBase
    {
        private readonly HttpClient client = new HttpClient();

        public ICommand SearchCourseByName_Click { get; set; }

        private VariableSizedWrapGrid _coursesContainer;

        private string courseName;
        public string CourseName
        {
            get { return courseName; }
            set
            {
                if (courseName != value)
                {
                    courseName = value;
                    RaisePropertyChanged(nameof(CourseName));
                }
            }
        }

        public EnrollInCourseViewModel(VariableSizedWrapGrid coursesContainer)
        {
            _coursesContainer = coursesContainer;

            client.BaseAddress = new Uri("http://localhost:56750/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

            SearchCourseByName_Click = new RelayCommand(new Action(SearchCourseByName));
        }

        private void SearchCourseByName()
        {
            _coursesContainer.Children.Clear();
            var searchedCourses = ProcessCoursesByName(CourseName);
        }

        private async Task<ObservableCollection<Course>> ProcessCoursesByName(string name)
        {
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));

            var streamTask = client.GetStreamAsync($"http://localhost:56750/api/enrollment/{name}");
            var searchedCourses = serializer.ReadObject(await streamTask) as ObservableCollection<Course>;

            foreach (var course in searchedCourses)
            {
                _coursesContainer.Children.Add(new CourseToEnrollInView(course));
            }
            return searchedCourses;
        }
    }
}
