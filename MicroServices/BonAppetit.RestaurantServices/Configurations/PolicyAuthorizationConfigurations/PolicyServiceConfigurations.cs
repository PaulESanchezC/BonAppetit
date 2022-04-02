using Configurations.ConfigurationsHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.PolicyBasedAuthServices.IsUserAdmin;
using StaticData;


namespace Configurations.PolicyAuthorizationConfigurations;

public static class PolicyServiceConfigurations
{
    public static IServiceCollection AddPolicyServiceConfiguration(this IServiceCollection services)
    {
        var scopeName = ProxyConfiguration.Use.GetSection("PolicyBasedAuth").GetValue<string>("ScopeRequirements");

        services.AddScoped<IAuthorizationHandler, IsScopeBonAppetit>();
        services.AddAuthorization(p =>
        {
            p.AddPolicy(PolicyAuthNames.ScopeRequirements, policy => policy.Requirements.Add(new IsScopeBonAppetitRequirement(scopeName)));
        });
        return services;
    }
}