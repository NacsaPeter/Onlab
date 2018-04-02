using Lynn.Client.Helpers;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lynn.Client.ViewModels
{
    public class EnrolledCoursesViewModel : ViewModelBase
    {
        private readonly HttpClient client = new HttpClient();

        private int userID;

        public int UserID
        {
            get { return userID; }
            set
            {
                if (userID != value)
                {
                    userID = value;
                    RaisePropertyChanged(nameof(UserID));
                }
            }
        }

        private ObservableCollection<Course> courses;

        public ObservableCollection<Course> Courses
        {
            get { return courses; }
            set
            {
                if (courses != value)
                {
                    courses = value;
                    RaisePropertyChanged(nameof(Courses));
                }
            }
        }

        public EnrolledCoursesViewModel()
        {
            Courses = new ObservableCollection<Course>();

            client.BaseAddress = new Uri("http://localhost:56749/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

            ListEnrolledCourses_Click = new RelayCommand(new Action(GetUserEnrolledCourses));
        }
        
        public ICommand ListEnrolledCourses_Click { get; set; }

        public void GetUserEnrolledCourses()
        {
            var enrolledCourses = ProcessCourses();
        }

        private async Task<ObservableCollection<Course>> ProcessCourses()
        {
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));

            var streamTask = client.GetStreamAsync($"http://localhost:56749/api/enrollment/{UserID}");
            var enrolledCourses = serializer.ReadObject(await streamTask) as ObservableCollection<Course>;

            Courses = enrolledCourses;
            return enrolledCourses;
        }

    }
}
