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
    public class EnrollmentService
    {
        private readonly Uri serverUrl = new Uri("http://localhost:56750/");

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public async Task<ObservableCollection<Course>> GetCoursesByNameAsync(string name)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));
                var streamTask = client.GetStreamAsync($"http://localhost:56750/api/enrollincourses/{name}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Course>;
            }
        }

        public async Task<Uri> EnrollInAsync(User user, Course course)
        {
            using (var client = new HttpClient())
            {
                Enrollment enrollment = new Enrollment { CourseId = course.ID, UserId = user.ID, Points = 0, Level = 1 };
                InitializeClient(client);
                HttpResponseMessage response = await client.PostAsJsonAsync("api/enrollment", enrollment);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
        }

        private void InitializeClient(HttpClient client)
        {
            client.BaseAddress = serverUrl;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollincourses"));
        }

    }
}
