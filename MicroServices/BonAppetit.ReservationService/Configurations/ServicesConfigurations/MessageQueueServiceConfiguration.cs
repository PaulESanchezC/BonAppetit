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

public static class MessageQueueServiceConfiguration
{
    public static IServiceCollection AddMessageQueueServicesConfigurations(this IServiceCollection services)
    {
        services.Configure<RabbitMqOptions>(ProxyConfiguration.Use.GetSection("RabbitMq"));

        services.AddHostedService<RabbitMqService>();

        services.AddSingleton<MessageQueueHandler>();
        services.AddSingleton<IRabbitMqService, RabbitMqService>();
        services.AddSingleton<IMessageQueueHandler, MessageQueueHandler>();

        return services;
    }
}