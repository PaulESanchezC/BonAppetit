using Microsoft.Extensions.DependencyInjection;
using Services.RestaurantServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfigurations
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection service)
    {
        service.AddScoped<IRestaurantService, RestaurantService>();
        return service;
    }
}