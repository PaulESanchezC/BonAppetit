using Microsoft.Extensions.DependencyInjection;
using Services.RestaurantServices;
using Services.UserRegistrationServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfigurations
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection service)
    {
        service.AddScoped<IUserRegistrationService, UserRegistrationService>();
        service.AddScoped<IRestaurantService, RestaurantService>();
        return service;
    }
}