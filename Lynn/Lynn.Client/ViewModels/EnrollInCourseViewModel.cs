using Lynn.Client.Helpers;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lynn.Client.ViewModels
{
    public class EnrollInCourseViewModel : ViewModelBase
    {
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

        private int courseID;

        public int CourseID
        {
            get { return courseID; }
            set
            {
                if (courseID != value)
                {
                    courseID = value;
                    RaisePropertyChanged(nameof(CourseID));
                }
            }
        }

        private readonly HttpClient client = new HttpClient();

        public EnrollInCourseViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:56749/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

            EnrollInCourse_Click = new RelayCommand(new Action(CreateNewEnrollment));
        }

        public ICommand EnrollInCourse_Click { get; set; }

        public void CreateNewEnrollment()
        {
            var uri = CreateEnrollmentAsync();
        }

        public async Task<Uri> CreateEnrollmentAsync()
        {

            Enrollment enrollment = new Enrollment { CourseId = CourseID, UserId = UserID, Level = 1, Points = 0 };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/enrollment", enrollment);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

    }
}
