using Configurations.ConfigurationsHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StaticData;

namespace Configurations.AuthorizationConfigurations;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationConfigurations(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerOptions.AuthenticationScheme).AddJwtBearer(JwtBearerOptions.AuthenticationScheme,
            options =>
            {
                options.Authority = ProxyConfiguration.Use.GetSection("AuthenticationService").GetValue<string>("BaseUrl");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    ValidIssuer = ProxyConfiguration.Use.GetSection("AuthenticationService").GetValue<string>("BaseUrl")
                };
            });
        return services;
    }
}