using AutoMapper;
using Models.ImageModels;
using Models.MenuItemModels;
using Models.MenuModels;
using Models.RestaurantModels;
using Models.ScheduleModels;
using Models.TableModels;


namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<ImageBase, ImageDto>().ReverseMap();
        CreateMap<ImageBase, ImageCreate>().ReverseMap();
        CreateMap<ImageDto, ImageCreate>().ReverseMap();
        CreateMap<ImageBase, ImageUpdate>().ReverseMap();
        CreateMap<ImageDto, ImageUpdate>().ReverseMap();

        CreateMap<MenuBase, MenuDto>().ReverseMap();
        CreateMap<MenuBase, MenuCreate>().ReverseMap();
        CreateMap<MenuDto, MenuCreate>().ReverseMap();
        CreateMap<MenuBase, MenuUpdate>().ReverseMap();
        CreateMap<MenuDto, MenuUpdate>().ReverseMap();

        CreateMap<MenuItemsBase, MenuItemsDto>().ReverseMap();
        CreateMap<MenuItemsBase, MenuItemsCreate>().ReverseMap();
        CreateMap<MenuItemsDto, MenuItemsCreate>().ReverseMap();
        CreateMap<MenuItemsBase, MenuItemsUpdate>().ReverseMap();
        CreateMap<MenuItemsDto, MenuItemsUpdate>().ReverseMap();

        CreateMap<RestaurantBase, RestaurantDto>().ReverseMap();
        CreateMap<RestaurantBase, RestaurantCreate>().ReverseMap();
        CreateMap<RestaurantDto, RestaurantCreate>().ReverseMap();
        CreateMap<RestaurantBase, RestaurantUpdate>().ReverseMap();
        CreateMap<RestaurantDto, RestaurantUpdate>().ReverseMap();

        CreateMap<ScheduleBase, ScheduleDto>().ReverseMap();
        CreateMap<ScheduleBase, ScheduleCreate>().ReverseMap();
        CreateMap<ScheduleDto, ScheduleCreate>().ReverseMap();
        CreateMap<ScheduleBase, ScheduleUpdate>().ReverseMap();
        CreateMap<ScheduleDto, ScheduleUpdate>().ReverseMap();

        CreateMap<TableBase, TableDto>().ReverseMap();
        CreateMap<TableBase, TableCreate>().ReverseMap();
        CreateMap<TableDto, TableCreate>().ReverseMap();
        CreateMap<TableBase, TableUpdate>().ReverseMap();
        CreateMap<TableDto, TableUpdate>().ReverseMap();
    }
}