using Configurations.ConfigurationsHelper;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;
using StaticData;

namespace Configurations.IdentityConfigurations.DuendeAuthenticationData;

public class AuthenticationClients
{
    //App Secrets For Bon Appetit Web App (clients WebApp)
    #region BonAppetitWebApp

    private static Secret ClientSecret { get; } = new(ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("ClientSecrets").Sha256());
    private static string ClientId { get; } = ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("ClientId");
    private static string ClientRedirectUris { get; } = ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("RedirectUris");
    private static string ClientPostLogoutRedirectUris { get; } = ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("PostLogoutRedirectUris");
    private static string ClientAllowedCorsOrigins { get; } = ProxyConfiguration.Use.GetSection("BonAppetitWebApp")
        .GetValue<string>("AllowedCorsOrigins");

    #endregion

    //App Secrets For Bon Appetit Manager App (manager WebApp)
    #region BonAppetitManagerApp

    private static Secret ManagerSecret { get; } = new(ProxyConfiguration.Use.GetSection("BonAppetitManagerApp")
        .GetValue<string>("ClientSecrets").Sha256());
    private static string ManagerId { get; } = ProxyConfiguration.Use.GetSection("BonAppetitManagerApp")
        .GetValue<string>("ClientId");
    private static string ManagerRedirectUris { get; } = ProxyConfiguration.Use.GetSection("BonAppetitManagerApp")
        .GetValue<string>("RedirectUris");
    private static string ManagerPostLogoutRedirectUris { get; } = ProxyConfiguration.Use.GetSection("BonAppetitManagerApp")
        .GetValue<string>("PostLogoutRedirectUris");
    private static string ManagerAllowedCorsOrigins { get; } = ProxyConfiguration.Use.GetSection("BonAppetitManagerApp")
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
               RedirectUris = { ClientRedirectUris },
               PostLogoutRedirectUris = { ClientPostLogoutRedirectUris },
               AllowedScopes = new List<string>
               {
                   IdentityServerConstants.LocalApi.ScopeName,
                   IdentityServerConstants.StandardScopes.OpenId,
                   IdentityServerConstants.StandardScopes.Profile,
                   IdentityServerConstants.StandardScopes.Email,
                   IdentityServerConstants.StandardScopes.Phone,
                   Scopes.bonAppetit,
                   Role.Client
               },
               AllowedCorsOrigins = { ClientAllowedCorsOrigins },
               AllowedGrantTypes = GrantTypes.Code,
           },
            new()
            {
                Enabled = true,
                ClientId = ManagerId,
                RequireClientSecret = false,
                RedirectUris = { ManagerRedirectUris },
                PostLogoutRedirectUris = { ManagerPostLogoutRedirectUris },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Phone,
                    Scopes.bonAppetit,
                    Role.Manager
                },
                AllowedCorsOrigins = { ManagerAllowedCorsOrigins },
                AllowedGrantTypes = GrantTypes.Code,
            }
        };
}