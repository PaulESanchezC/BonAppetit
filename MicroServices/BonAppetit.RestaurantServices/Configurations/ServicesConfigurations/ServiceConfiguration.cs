using Microsoft.Extensions.DependencyInjection;
using Services.Repository.ImageRepository;
using Services.Repository.MenuItemRepository;
using Services.Repository.MenuRepository;
using Services.Repository.RestaurantRepository;
using Services.Repository.ScheduleRepository;
using Services.Repository.TableRepository;
using Services.TableTimeBracketsService;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IMenuItemService, MenuItemService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<ITableTimeBracketService, TableTimeBracketService>();
        return services;
    }
}