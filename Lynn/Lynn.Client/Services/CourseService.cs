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
        public async Task<ObservableCollection<Test>> GetTestsByCourseID(int courseID)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/tests"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Test>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/tests/{courseID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Test>;
            }
        }

        public async Task<TestTrying> GetTestTrying(int userId, int testId)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/tests"));

                var serializer = new DataContractJsonSerializer(typeof(TestTrying));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/tests/{userId}/{testId}");
                return serializer.ReadObject(await streamTask) as TestTrying;
            }
        }

        public async Task<ObservableCollection<VocabularyExercise>> GetVocabularyExercises(Test test)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercises"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<VocabularyExercise>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/exercises/{test.ID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<VocabularyExercise>;
            }
        }
    }
}
