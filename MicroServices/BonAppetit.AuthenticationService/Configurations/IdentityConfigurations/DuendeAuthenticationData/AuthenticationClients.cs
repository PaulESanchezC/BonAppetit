using Configurations.ConfigurationsHelper;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;

namespace Configurations.IdentityConfigurations.DuendeAuthenticationData;

public class AuthenticationClients
{

    #region Bon Appetit App Options
    private static Secret ClientSecret { get;  } = new (ProxyConfiguration.Use.GetSection("Clients").GetSection("BonAppetitApp")
        .GetValue<string>("ClientSecrets").Sha256());
    private static string ClientId { get; set; } = ProxyConfiguration.Use.GetSection("Clients").GetSection("BonAppetitApp")
        .GetValue<string>("ClientId");
    private static string RedirectUris { get; set; } = ProxyConfiguration.Use.GetSection("Clients").GetSection("BonAppetitApp")
        .GetValue<string>("RedirectUris");
    private static string PostLogoutRedirectUris { get; set; } = ProxyConfiguration.Use.GetSection("Clients").GetSection("BonAppetitApp")
        .GetValue<string>("PostLogoutRedirectUris");
    private static string AllowedCorsOrigins { get; set; } = ProxyConfiguration.Use.GetSection("Clients").GetSection("BonAppetitApp")
        .GetValue<string>("AllowedCorsOrigins");

    #endregion


    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
           new()
            {
                Enabled = true,
                ClientId = ClientId,
                ClientSecrets = {ClientSecret},
                RedirectUris = { RedirectUris },
                PostLogoutRedirectUris = { PostLogoutRedirectUris },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Phone,
                    Scopes.bonAppetit
                },
                AllowedCorsOrigins = { AllowedCorsOrigins },
                AllowedGrantTypes = GrantTypes.Code
            }
        };
}