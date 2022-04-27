using Microsoft.Extensions.DependencyInjection;
using Services.ReservationServices;
using Services.RestaurantServices;
using Services.ScheduleServices;
using Services.TableServices;
using Services.UserRegistrationServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfigurations
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection service)
    {
        service.AddScoped<IUserRegistrationService, UserRegistrationService>();
        service.AddScoped<IRestaurantService, RestaurantService>();
        service.AddScoped<IScheduleServices, ScheduleServices>();
        service.AddScoped<ITableService,TableService>();
        service.AddScoped<IReservationService, ReservationService>();
        return service;
    }
}