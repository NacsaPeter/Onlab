using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Services
{
    public class CountriesService
    {
        private readonly Uri serverUrl = new Uri("https://restcountries.eu");

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

        public async Task<ObservableCollection<Country>> GetCountriesByLanguageCode(string code)
        {
            var result = await GetAsync<ObservableCollection<Country>>(new Uri(serverUrl, $"rest/v2/lang/{code}"));
            return result;
        }

        public async Task<Language> GetLanguageByLanguageCode(string code)
        {
            var result = await GetAsync<ObservableCollection<Country>>(new Uri(serverUrl, $"rest/v2/lang/{code}"));
            Language language = null;
            foreach (var item in result[0].Languages)
            {
                if (item.Iso639_1 == code || item.Iso639_2 == code)
                {
                    language = item;
                }
            }
            return language;
        }
    }
}
