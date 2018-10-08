using Lynn.DTO;
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
                RegisterUserDTO registerUser = new RegisterUserDTO { UserName = userName, Email = email, Password = password };
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent _Body = new StringContent("{\"UserName\": \"" + userName +
                    "\",\"Email\": \"" + email + "\",\"Password\": \"" + password + "\"}");
                _Body.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:57770/api/account", _Body);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
        }
    }
}
