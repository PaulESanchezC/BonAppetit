using Microsoft.Extensions.DependencyInjection;

namespace Configurations.AuthenticationConfigurations;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationCOnfiguration(this IServiceCollection services)
    {
        services.AddAuthentication();
        return services;
    }
    
}