using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lynn.WebAPI.Identity
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("lynnapi", "Lynn API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                 new Client
                 {
                     ClientId = "ro.client",
                     AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                     ClientSecrets =
                     {
                         new Secret("secret".Sha256())
                     },
                     AllowedScopes = { "lynnapi" }
                 }
            };
        }
    }
}
