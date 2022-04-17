using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using StaticData;

namespace Configurations.IdentityConfigurations.DuendeAuthenticationData;

public static class Scopes
{
    public const string bonAppetit = "BonAppetit";
    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new ApiScope(bonAppetit),
        new ApiScope(Role.Manager),
        new ApiScope(Role.Client),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
    };

}