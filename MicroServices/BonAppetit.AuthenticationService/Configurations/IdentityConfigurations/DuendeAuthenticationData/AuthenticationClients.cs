using Configurations.ConfigurationsHelper;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;

namespace Configurations.IdentityConfigurations.DuendeAuthenticationData;

public class AuthenticationClients
{
    private static string ClientSecret { get; set; } = ProxyConfiguration.Use.GetSection("Clients").GetSection("RestaurantManager")
        .GetValue<string>("ClientId");
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
           new()
            {
                Enabled = true,
                ClientId = "Restaurant Manager",
                ClientSecrets = {new Secret("secret".Sha256()) },
                RedirectUris = { "https://localhost:44324/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:44324/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Phone,
                    Scopes.bonAppetit
                },
                AllowedCorsOrigins = { "https://localhost:44324" },
                AllowedGrantTypes = GrantTypes.Code
            }
        };
}