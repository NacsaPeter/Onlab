using Lynn.DTO;
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
    public class UserService : BaseHttpService
    {
        public async Task<User> GetUserByName(string username)
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/user"));

                var serializer = new DataContractJsonSerializer(typeof(User));
                var streamTask = client.GetStreamAsync($"{BaseUrl}/api/user/{username}");
                return serializer.ReadObject(await streamTask) as User;
            }
        }
    }
}
