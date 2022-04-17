using Microsoft.Extensions.DependencyInjection;
using Services.RegistrationServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IRegistrationService, RegistrationService>();
        return services;
    }
}