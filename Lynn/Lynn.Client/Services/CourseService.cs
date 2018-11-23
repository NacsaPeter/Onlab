using Lynn.Client.ViewModels;
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

namespace Lynn.Client.Services
{
    public class CourseService : BaseHttpService
    {
        public async Task<ObservableCollection<Course>> GetCoursesByNameAsync(string name)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/course"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/course/name/{name}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Course>;
            }
        }

        public async Task<ObservableCollection<Course>> GetEnrolledCourses(User user)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/course"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/course/enrolled/{user.ID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Course>;
            }
        }
    }
}
