using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Configurations.AuthenticationConfigurations;

public class AuthMessageHandler : AuthorizationMessageHandler
{
    public AuthMessageHandler(IAccessTokenProvider provider, NavigationManager navigation) : base(provider, navigation)
    {
        ConfigureHandler(new[] { "https://localhost:44352/" });
    }
}