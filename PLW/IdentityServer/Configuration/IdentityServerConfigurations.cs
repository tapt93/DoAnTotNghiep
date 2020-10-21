using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer.Configuration
{
    public class IdentityServerConfigurations
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("plw_api", "PLW API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    //RedirectUris = new List<string>(uris),
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "openid",
                        "profile",
                        "offline_access",
                        "plw_api",
                    },
                    AllowOfflineAccess = true,
                    Enabled = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = new List<string>{ "http://localhost:3000" },
                    AccessTokenType = AccessTokenType.Jwt,
                    IdentityTokenLifetime = 3000,
                    AccessTokenLifetime = 3600*24*30,
                    AuthorizationCodeLifetime = 300
                }
            };
        }

        public static Claim[] GetUserClaims(string user)
        {
            string result = string.Empty;



            return new Claim[]
            {
                new Claim("Full Name", "NGUYEN TUAN ANH" )
            };
        }
    }

}
