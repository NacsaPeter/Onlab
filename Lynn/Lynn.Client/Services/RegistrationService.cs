using Lynn.DTO;
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
    public class RegistrationService : BaseHttpService
    {
        public async Task<Uri> Register(string userName, string email, string password)
        {
            using (var client = new HttpClient())
            {
                RegisterUserDTO registerUser = new RegisterUserDTO
                {
                    UserName = userName,
                    Email = email,
                    Password = password
                };
                
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/account"));

                var content = new StringContent(JsonConvert.SerializeObject(registerUser), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{BaseUrl}/api/account", content);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
        }
    }
}
