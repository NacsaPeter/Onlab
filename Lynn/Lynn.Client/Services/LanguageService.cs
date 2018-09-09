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
    public class LanguageService : BaseHttpService
    {
        public async Task<ObservableCollection<Language>> GetLanguages()
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Language>));
                var streamTask = client.GetStreamAsync($"http://localhost:44344/api/language");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Language>;
            }
        }

        public async Task<ObservableCollection<Course>> GetCoursesByLanguageCode(string knownCode, string learningCode)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));
                var streamTask = client.GetStreamAsync($"http://localhost:44344/api/language/{knownCode}/{learningCode}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Course>;
            }
        }
    }
}
