using Lynn.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Services
{
    public class EnrollmentService : BaseHttpService
    {
        public async Task<ObservableCollection<Course>> GetCoursesByNameAsync(string name)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollincourses"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/enrollincourses/{name}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Course>;
            }
        }

        public async Task<Uri> EnrollInAsync(User user, Course course)
        {
            using (var client = new HttpClient())
            {
                Enrollment enrollment = new Enrollment
                {
                    CourseID = course.ID,
                    UserID = user.ID,
                    Points = 0,
                    Level = 1
                };

                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/enrollment", enrollment);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
        }

        public async Task<ObservableCollection<Course>> GetEnrolledCourses(User user)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrolledcourses"));
            
                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/enrolledcourses/{user.ID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Course>;
            }
        }

    }
}
