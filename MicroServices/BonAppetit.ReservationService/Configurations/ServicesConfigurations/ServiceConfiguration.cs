using Configurations.ConfigurationsHelper;
using Microsoft.Extensions.DependencyInjection;
using Models.Options;
using Services.RabbitMqService;
using Services.Repository.ReservationServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IRabbitMqService, RabbitMqService>();
        services.AddHostedService<RabbitMqService>();
        services.Configure<RabbitMqOptions>(ProxyConfiguration.Use.GetSection("RabbitMq"));
        return services;
    }
}