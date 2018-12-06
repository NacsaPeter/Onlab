using IdentityModel.Client;
using Lynn.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Services
{
    public static class LogInService
    {
        public static async Task<string> LogIn(User user)
        {
            // discover endpoints from metadata
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            string baseurl = resourceLoader.GetString("BaseUri");
            var disco = await DiscoveryClient.GetAsync(baseurl);
            if (disco.IsError)
            {
                return "";
            }
            else
            {
                // request token
                var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
                var tokenResponse = await tokenClient
                .RequestResourceOwnerPasswordAsync(user.Username, user.Password, "lynnapi");
                if (tokenResponse.IsError)
                {
                    return "";
                }
                else
                {
                    return tokenResponse.AccessToken;
                }
            }
        }
    }
}
