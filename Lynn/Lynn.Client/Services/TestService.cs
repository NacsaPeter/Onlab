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
    public class TestService: BaseHttpService
    {
        public async Task<TestTrying> GetTestTrying(int userId, int testId)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/test"));

                var serializer = new DataContractJsonSerializer(typeof(TestTrying));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/test/trying/{userId}/{testId}");
                return serializer.ReadObject(await streamTask) as TestTrying;
            }
        }

        public async Task<int> PostTestResult(User user, Test test, TestResultDto testResult)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/test"));

                HttpResponseMessage response = await client
                    .PostAsJsonAsync($"api/test/result/{user.ID}/{test.ID}", testResult);
                response.EnsureSuccessStatusCode();

                var serializer = new DataContractJsonSerializer(typeof(int));
                return (int)serializer.ReadObject(await response.Content.ReadAsStreamAsync());
            }
        }

        public async Task<ObservableCollection<Test>> GetTestsByCourseId(int courseId)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/test"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Test>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/test/course/{courseId}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Test>;
            }
        }
    }
}
