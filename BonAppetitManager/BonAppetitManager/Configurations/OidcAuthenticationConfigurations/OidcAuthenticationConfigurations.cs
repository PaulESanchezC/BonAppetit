using Microsoft.Extensions.DependencyInjection;

namespace Configurations.OidcAuthenticationConfigurations;

public static class OidcAuthenticationConfigurations
{
    public static IServiceCollection AddOidcAuthenticationConfigurations(this IServiceCollection services)
    {
        services.AddScoped<CustomAuthenticationMessageHandler>();
        services.AddHttpClient("api", opt => opt.BaseAddress = new Uri("https://localhost:44352/"))
        .AddHttpMessageHandler<CustomAuthenticationMessageHandler>();
        services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("api"));

        services.AddOidcAuthentication(opt =>
        {
            opt.ProviderOptions.Authority = "https://localhost:44352/";
            opt.ProviderOptions.ClientId = "99f64badca86";
            opt.ProviderOptions.ResponseType = "code";
            opt.ProviderOptions.RedirectUri = "https://localhost:44355/";
            opt.ProviderOptions.PostLogoutRedirectUri = "https://localhost:44355/";

            opt.ProviderOptions.DefaultScopes.Add("openid");
            opt.ProviderOptions.DefaultScopes.Add("profile");
            opt.ProviderOptions.DefaultScopes.Add("email");
            opt.ProviderOptions.DefaultScopes.Add("phone");
            opt.ProviderOptions.DefaultScopes.Add("BonAppetit");
            opt.ProviderOptions.DefaultScopes.Add("manager");

            opt.UserOptions.NameClaim = "name";
            opt.UserOptions.RoleClaim = "role";
        });
        return services;
    }
}