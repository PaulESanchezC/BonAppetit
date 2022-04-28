using Configurations.ConfigurationsHelper;
using Microsoft.Extensions.DependencyInjection;
using Models.Options;
using Services.PaymentServices;
using Services.RabbitMqSender;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IPaymentServices, PaymentServices>();
        services.AddScoped<IPaymentMessageSender, PaymentMessageSender>();
        services.Configure<RabbitMqOptions>(ProxyConfiguration.Use.GetSection("RabbitMq"));
        return services;
    }
}