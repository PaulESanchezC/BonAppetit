using AutoMapper;
using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Options;
using Services.MessageQueueHandlerService;
using Services.RabbitMqService;
using Services.Repository.ReservationServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IReservationService, ReservationService>();
        return services;
    }
}