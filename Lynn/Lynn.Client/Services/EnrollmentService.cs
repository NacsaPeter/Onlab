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
        public async Task<bool> EnrollInAsync(User user, Course course)
        {
            using (var client = new HttpClient())
            {
                Enrollment enrollment = new Enrollment
                {
                    CourseId = course.Id,
                    UserId = user.ID,
                    Points = 0,
                    Level = 1
                };

                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/enrollment", enrollment);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<Enrollment> GetEnrollment(int userId, int courseId)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

                var serializer = new DataContractJsonSerializer(typeof(Enrollment));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/enrollment/{userId}/{courseId}");
                return serializer.ReadObject(await streamTask) as Enrollment;
            }
        }

    }
}
