using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Configurations.SwaggerGenConfigurations;

public static class SwaggerGenConfiguration
{
    public static IServiceCollection AddSwaggerGenConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        return services;
    }
}