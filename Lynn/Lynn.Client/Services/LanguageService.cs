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
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/language"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Language>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/language");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Language>;
            }
        }

        public async Task<ObservableCollection<Course>> GetCoursesByLanguageCode(string knownCode, string learningCode)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/language"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/language/{knownCode}/{learningCode}");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Course>;
            }
        }

        public async Task<ObservableCollection<Territory>> GetTerritories()
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/language"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Territory>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/language/territory");
                return serializer.ReadObject(await streamTask) as ObservableCollection<Territory>;
            }
        }

        public async Task<ObservableCollection<CourseLevelDto>> GetCourseLevels()
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/language"));

                var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<CourseLevelDto>));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/language/levels");
                return serializer.ReadObject(await streamTask) as ObservableCollection<CourseLevelDto>;
            }
        }
    }
}
