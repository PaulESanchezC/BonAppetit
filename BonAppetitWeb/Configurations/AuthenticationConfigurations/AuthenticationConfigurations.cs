using Configurations.ConfigurationsHelper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configurations.AuthenticationConfigurations;

public static class AuthenticationConfigurations
{
    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = ProxyConfiguration.Use.GetSection("BonAppetitApp").GetValue<string>("Authority");
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClientId = ProxyConfiguration.Use.GetSection("BonAppetitApp").GetValue<string>("ClientId"); 
                options.ClientSecret = ProxyConfiguration.Use.GetSection("BonAppetitApp").GetValue<string>("ClientSecrets");
                options.ResponseType = "code";

                options.ClaimActions.MapJsonKey("role", "role", "role");
                options.ClaimActions.MapJsonKey("sub", "sub", "sub");

                options.TokenValidationParameters.NameClaimType = "name";
                options.TokenValidationParameters.RoleClaimType = "role";

                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("phone");
                options.Scope.Add(ProxyConfiguration.Use.GetSection("BonAppetitApp").GetValue<string>("ClientName"));

                options.SaveTokens = true;

            });
        return services;
    }
}