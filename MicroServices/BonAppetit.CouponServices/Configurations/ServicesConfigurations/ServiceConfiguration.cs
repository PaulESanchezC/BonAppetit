using Configurations.ConfigurationsHelper;
using Microsoft.Extensions.DependencyInjection;
using Models.Options;
using Services.CouponService;
using Services.CouponServices;
using Services.CouponTypeService;
using Services.VerifyCouponServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<ICouponService, CouponService>();
        services.AddScoped<ICouponTypeService, CouponTypeService>();
        services.AddScoped<IVerifyCouponService,VerifyCouponService>();

        services.Configure<RabbitMqOptions>(ProxyConfiguration.Use.GetSection("RabbitMq"));
        return services;
    }
}