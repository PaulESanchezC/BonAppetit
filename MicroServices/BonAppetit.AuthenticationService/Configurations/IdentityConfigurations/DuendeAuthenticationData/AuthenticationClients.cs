using Configurations.ConfigurationsHelper;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;

namespace Configurations.IdentityConfigurations.DuendeAuthenticationData;

public class AuthenticationClients
{
    //App Secrets For Bon Appetit Web App (clients WebApp)
    #region BonAppetitWebApp

    private static Secret ClientSecret { get; } = new(ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("ClientSecrets").Sha256());
    private static string ClientId { get; } = ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("ClientId");
    private static string RedirectUris { get; } = ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("RedirectUris");
    private static string PostLogoutRedirectUris { get; } = ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("PostLogoutRedirectUris");
    private static string AllowedCorsOrigins { get; } = ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("AllowedCorsOrigins");

    #endregion

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
           {
               Enabled = true,
               ClientId = ClientId,
               RequireClientSecret = false,
               RedirectUris = { RedirectUris },
               PostLogoutRedirectUris = { PostLogoutRedirectUris },
               AllowedScopes = new List<string>
               {
                   IdentityServerConstants.LocalApi.ScopeName,
                   IdentityServerConstants.StandardScopes.OpenId,
                   IdentityServerConstants.StandardScopes.Profile,
                   IdentityServerConstants.StandardScopes.Email,
                   IdentityServerConstants.StandardScopes.Phone,
                   Scopes.bonAppetit
               },
               AllowedCorsOrigins = { AllowedCorsOrigins },
               AllowedGrantTypes = GrantTypes.Code,
           }
        };
}