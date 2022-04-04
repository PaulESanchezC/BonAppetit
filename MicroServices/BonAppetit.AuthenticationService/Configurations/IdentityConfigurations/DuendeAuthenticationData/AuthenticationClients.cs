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
                ClientName = ProxyConfiguration.Use.GetSection("Clients").GetSection("RestaurantManager").GetValue<string>("ClientName"),
                ClientId = ProxyConfiguration.Use.GetSection("Clients").GetSection("RestaurantManager").GetValue<string>("ClientId"),
                ClientSecrets = {new Secret(ClientSecret.Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { ProxyConfiguration.Use.GetSection("Clients").GetSection("RestaurantManager").GetValue<string>("RedirectUris"), },
                PostLogoutRedirectUris = { ProxyConfiguration.Use.GetSection("Clients").GetSection("RestaurantManager").GetValue<string>("PostLogoutRedirectUris"), },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Phone,
                    Scopes.bonAppetit
                }
            }
        };
}