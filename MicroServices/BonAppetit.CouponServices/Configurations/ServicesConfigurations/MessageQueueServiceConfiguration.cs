using Configurations.ConfigurationsHelper;
using Microsoft.Extensions.DependencyInjection;
using Models.Options;
using Services.MessageQueueHandlerService;
using Services.RabbitMqService;

namespace Configurations.ServicesConfigurations;

public static class MessageQueueServiceConfiguration
{
    public static IServiceCollection AddMessageQueueServicesConfigurations(this IServiceCollection services)
    {
        services.Configure<RabbitMqOptions>(ProxyConfiguration.Use.GetSection("RabbitMq"));

        services.AddHostedService<RabbitMqService>();

        services.AddSingleton<IRabbitMqService, RabbitMqService>();
        services.AddSingleton<IMessageQueueHandler, MessageQueueHandler>();

        return services;
    }
}