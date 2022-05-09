using Microsoft.Extensions.DependencyInjection;
using Services.CouponServices;
using Services.EmailServices;
using Services.PaymentServices;
using Services.ReservationServices;
using Services.RestaurantServices;
using Services.TableServices;
using Services.UserRegistrationServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfigurations
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection service)
    {
        service.AddScoped<IUserRegistrationService, UserRegistrationService>();
        service.AddScoped<IRestaurantService, RestaurantService>();
        service.AddScoped<IReservationServices, ReservationServices>();
        service.AddScoped<ITableService, TableService>();
        service.AddScoped<IPaymentService, PaymentService>();
        service.AddScoped<IEmailSender, EmailSender>();
        service.AddScoped<ICouponServices, CouponServices>();
        return service;
    }
}