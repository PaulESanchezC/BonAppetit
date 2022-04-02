using Microsoft.Extensions.DependencyInjection;
using Models.RestaurantModels;
using Services.HttpClientServices;
using Services.RestaurantServices;

namespace Configurations.HttpCLientConfigurations;

public static class HttpClientConfiguration
{
    public static IServiceCollection AddHttpClientServiceConfigurations(this IServiceCollection services)
    {
        services.AddHttpClient<IHttpClientService<Restaurant>>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:44310/");
        });
        return services;
    }
}