using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Services
{
    public class LanguageService
    {
        private readonly Uri serverUrl = new Uri("http://localhost:56750/");

        private void InitializeClient(HttpClient client)
        {
            client.BaseAddress = serverUrl;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/language"));
        }

        public async Task<Dictionary<string, string>> GetLanguageCodesDictionary()
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                var serializer = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
                var streamTask = client.GetStreamAsync($"http://localhost:56750/api/language");
                return serializer.ReadObject(await streamTask) as Dictionary<string, string>;
            }
        }

        public async Task<Dictionary<string, string>> GetTerritoryCodesDictionary()
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                var serializer = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
                var streamTask = client.GetStreamAsync($"http://localhost:56750/api/language/territory");
                return serializer.ReadObject(await streamTask) as Dictionary<string, string>;
            }
        }
    }
}
