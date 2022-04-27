using Microsoft.Extensions.DependencyInjection;
using Services.CouponServices;
using Services.CouponTypeService;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<ICouponService, CouponService>();
        services.AddScoped<ICouponTypeService, CouponTypeService>();
        return services;
    }
}