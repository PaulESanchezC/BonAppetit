using Configurations.ProfileServiceConfigurations;
using Duende.IdentityServer.Services;
using Microsoft.Extensions.DependencyInjection;
using Services.AccountsServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IAccountsService, AccountsService>();
        services.AddScoped<IProfileService, ProfileService>();
        return services;
    }
}