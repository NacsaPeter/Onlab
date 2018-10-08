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
        private readonly Uri serverUrl = new Uri("http://localhost:57770/");

        protected void InitializeClient(HttpClient client)
        {
            client.BaseAddress = serverUrl;
            client.SetBearerToken(MainViewModel.AccessToken);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/tests"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollincourses"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrolledcourses"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/language"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/exercises"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/user"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/account"));
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
