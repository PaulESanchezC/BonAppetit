using Microsoft.Extensions.DependencyInjection;

namespace Configurations.AuthenticationConfigurations;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddOidcAuthentication(options =>
        {
            options.ProviderOptions.Authority = "https://localhost:44352/";
            options.ProviderOptions.ClientId = "c5d220ab-8dfd-49d6-bbc9-66015eda915c";
            options.ProviderOptions.ResponseType = "code";
            options.ProviderOptions.DefaultScopes.Add("profile");
            options.ProviderOptions.DefaultScopes.Add("email");
            options.ProviderOptions.DefaultScopes.Add("openid");
            options.ProviderOptions.DefaultScopes.Add("phone");
            options.ProviderOptions.DefaultScopes.Add("Bon Appetit");
            options.ProviderOptions.DefaultScopes.Add("restaurant");
        });

        services.AddScoped<AuthMessageHandler>();

        services.AddHttpClient("authentication", options => options.BaseAddress = new Uri("https://localhost:44352/"))
            .AddHttpMessageHandler<AuthMessageHandler>();
        services.AddScoped(provider =>
            provider.GetRequiredService<IHttpClientFactory>().CreateClient("authentication"));
        return services;
    }
}