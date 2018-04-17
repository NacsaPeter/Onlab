using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.ViewModels
{
    public class DetailedCourseToEnrollInViewModel : ViewModelBase
    {
        private readonly HttpClient client = new HttpClient();

        public DetailedCourseToEnrollInViewModel(Course course)
        {
            Course = course;

            client.BaseAddress = new Uri("http://localhost:56750/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));
        }

        private Course course;
        public Course Course
        {
            get { return course; }
            set
            {
                if (course != value)
                {
                    course = value;
                    RaisePropertyChanged(nameof(Course));
                }
            }
        }

        public async Task<Uri> EnrollInAsync()
        {
            User loggedInUser = new User { ID = 6, Username = "TestUser15", Email = "testuser@lynn.com", PasswordHash = "lukztthrgh34hb", Points = 0 };
            Enrollment enrollment = new Enrollment { CourseId = Course.ID, UserId = loggedInUser.ID, Points = 0, Level = 1 };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/enrollment", enrollment);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}
