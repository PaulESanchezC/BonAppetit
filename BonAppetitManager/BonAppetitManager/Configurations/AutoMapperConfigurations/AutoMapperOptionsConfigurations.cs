using AutoMapper;
using Models.RestaurantModels;
using Models.ScheduleModels;


namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<Restaurant, RestaurantCreate>().ReverseMap();
        CreateMap<Restaurant, RestaurantUpdate>().ReverseMap();

        CreateMap<Schedule, ScheduleUpdate>().ReverseMap();
    }
}