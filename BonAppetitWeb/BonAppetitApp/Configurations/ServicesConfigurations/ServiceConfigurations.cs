using Microsoft.Extensions.DependencyInjection;
using Services.EmailServices;
using Services.PaymentServices;
using Services.ReservationServices;
using Services.RestaurantServices;
using Services.TableServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfigurations
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection service)
    {
        service.AddScoped<IRestaurantService, RestaurantService>();
        service.AddScoped<IReservationServices, ReservationServices>();
        service.AddScoped<ITableService, TableService>();
        service.AddScoped<IPaymentService, PaymentService>();
        service.AddScoped<IEmailSender, EmailSender>();
        return service;
    }
}