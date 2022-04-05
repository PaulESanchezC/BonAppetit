using Microsoft.Extensions.DependencyInjection;

namespace ClientConfigurations.ClientAuthenticationConfigurations;

public static class ClientAuthenticationConfigurations
{
    public static IServiceCollection AddClientAuthenticationConfiguration(this IServiceCollection services)
    {
        return services;
    }
}