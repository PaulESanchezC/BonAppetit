using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Services.EmailServices;


namespace Configurations.ServicesConfigurations;

public static class ServicesConfiguration
{
    public static IServiceCollection AddRepositoryServicesConfigurations(this IServiceCollection services)
    {
        //EmailSender Services
        services.AddTransient<IMailJetEmailSender, EmailSender>();
        return services;
    }
}