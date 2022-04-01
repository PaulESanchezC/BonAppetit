using Duende.IdentityServer.Models;

namespace Configurations.IdentityConfigurations.DuendeAuthenticationData;

public static class Resources
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Phone(),
            new IdentityResources.Profile()
        };



}