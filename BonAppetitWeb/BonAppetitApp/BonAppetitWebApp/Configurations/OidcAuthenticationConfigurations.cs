namespace BonAppetitWebApp.Configurations;

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
            opt.ProviderOptions.ClientId = "e3b051597bf7";
            opt.ProviderOptions.ResponseType = "code";
            opt.ProviderOptions.PostLogoutRedirectUri = "https://localhost:44343/logout-callback";
            opt.ProviderOptions.RedirectUri = "https://localhost:44343/login-callback";

            opt.ProviderOptions.AdditionalProviderParameters.Add("ClientSecrets", "ff972fdf-6b37-45ef-aa1b-e3b051597bf7");

            opt.ProviderOptions.DefaultScopes.Add("openid");
            opt.ProviderOptions.DefaultScopes.Add("profile");
            opt.ProviderOptions.DefaultScopes.Add("email");
            opt.ProviderOptions.DefaultScopes.Add("phone");
            opt.ProviderOptions.DefaultScopes.Add("BonAppetit");
        });
        return services;
    }
}