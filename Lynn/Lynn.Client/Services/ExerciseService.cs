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
    public class ExerciseService: BaseHttpService
    {
        public async Task<ObservableCollection<VocabularyExercise>> GetVocabularyExercises(Test test)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercise"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<VocabularyExercise>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/exercise/test/{test.ID}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<VocabularyExercise>;
            }
        }
    }
}
