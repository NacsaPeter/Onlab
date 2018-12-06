using Lynn.Client.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Services
{
    public abstract class BaseHttpService
    {
        public static string BaseUrl
        {
            get
            {
                var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
                return resourceLoader.GetString("BaseUri");
            }
        }

        private readonly Uri serverUrl = new Uri(BaseUrl);

        protected void InitializeClient(HttpClient client)
        {
            client.BaseAddress = serverUrl;
            client.SetBearerToken(MainViewModel.AccessToken);
            client.DefaultRequestHeaders.Accept.Clear();
        }

        protected async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

    }
}
