using AutoMapper;

using Models.ReservationModels;


namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<ReservationDto, ReservationBase>().ReverseMap();
    }
}