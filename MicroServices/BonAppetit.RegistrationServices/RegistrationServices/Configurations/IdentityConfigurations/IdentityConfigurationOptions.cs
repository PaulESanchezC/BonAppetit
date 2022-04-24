using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Models.ApplicationUserModels;

namespace Configurations.IdentityConfigurations;

public static class IdentityConfigurationOptions
{
    public static IServiceCollection AddIdentityConfigurationOptions(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password = PasswordOptionsConfigurations(options.Password);
                options.Lockout = LockoutOptionsConfigurations(options.Lockout);
                options.Tokens = TokenOptionsConfigurations(options.Tokens);
            }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        return services;
    }
    public static PasswordOptions PasswordOptionsConfigurations(this PasswordOptions options)
    {
        options.RequireUppercase = true;
        options.RequireLowercase = true;
        options.RequireDigit = false;
        options.RequireNonAlphanumeric = false;

        options.RequiredLength = 4;
        options.RequiredUniqueChars = 0;
        return options;
    }
    public static TokenOptions TokenOptionsConfigurations(this TokenOptions options)
    {
        return options;
    }
    public static LockoutOptions LockoutOptionsConfigurations(this LockoutOptions options)
    {
        options.AllowedForNewUsers = false;
        return options;
    }
}