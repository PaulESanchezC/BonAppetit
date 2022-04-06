using Configurations.IdentityConfigurations.DuendeAuthenticationData;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Models.ApplicationUserModels;

namespace Configurations.IdentityConfigurations;

public static class IdentityConfigurationOptions
{
    public static IServiceCollection AddIdentityConfigurationOptions(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer(options =>
            {
                options.UserInteraction.LoginUrl = "/Account/Login";
                options.UserInteraction.LogoutUrl = "/Account/Logout";
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            }).AddInMemoryIdentityResources(Resources.IdentityResources)
            .AddInMemoryApiScopes(Scopes.ApiScopes)
            .AddInMemoryClients(AuthenticationClients.Clients)
            .AddAspNetIdentity<ApplicationUser>()
            .AddDeveloperSigningCredential();

        return services;
    }
}