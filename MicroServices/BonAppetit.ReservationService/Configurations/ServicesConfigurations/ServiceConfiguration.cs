using Microsoft.Extensions.DependencyInjection;
using Services.RabbitMqService;
using Services.Repository.ReservationServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IReservationService, ReservationService>();

        services.AddHostedService<IRabbitMqService>();
        return services;
    }
}