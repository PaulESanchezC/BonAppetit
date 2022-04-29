using Configurations.ConfigurationsHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Models.Options;
using Services.EmailServices;


namespace Configurations.ServicesConfigurations;

public static class ServicesConfiguration
{
    public static IServiceCollection AddRepositoryServicesConfigurations(this IServiceCollection services)
    {
        //EmailSender Services
        services.AddTransient<IMailJetEmailSender, EmailSender>();

        //MailJet Options Service
        services.Configure<MailjetOptions>(ProxyConfiguration.Use.GetSection("MailJet"));

        return services;
    }
}