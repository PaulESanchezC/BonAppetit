using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ClientConfigurations.ClientAuthenticationConfigurations;

public static class ClientAuthenticationConfigurations
{
    public static IServiceCollection AddClientAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddAuthorizationCore();
        services.AddScoped<AuthenticationStateProvider, BffAuthenticationStateProvider>();

        services.AddTransient<AntiForgeryHandler>();
        services.AddHttpClient("backend", client => client.BaseAddress = new Uri("https://localhost:7074"))
            .AddHttpMessageHandler<AntiForgeryHandler>();

        services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("backend"));
        return services;
    }
}