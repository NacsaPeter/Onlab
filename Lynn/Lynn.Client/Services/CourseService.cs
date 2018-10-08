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
        private readonly Uri serverUrl = new Uri("http://localhost:57770/");

        public async Task<ObservableCollection<Test>> GetTestsByCourseID(int courseID)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Test>));
                var streamTask = client.GetStreamAsync($"http://localhost:57770/api/tests/{courseID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Test>;
            }
        }

        public async Task<ObservableCollection<VocabularyExercise>> GetVocabularyExercises(Test test)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<VocabularyExercise>));
                var streamTask = client.GetStreamAsync($"http://localhost:57770/api/exercises/{test.ID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<VocabularyExercise>;
            }
        }
    }
}
