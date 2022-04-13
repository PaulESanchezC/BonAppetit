using Microsoft.Extensions.DependencyInjection;
using Services.PaymentServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IPaymentServices, PaymentServices>();
        return services;
    }
}