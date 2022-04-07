using AutoMapper;
using Models.ApplicationUserModels;
using Models.ReservationModels;


namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<ReservationDto, ReservationBase>().ReverseMap();
        
        CreateMap<AnonymousUser, AnonymousUserDto>().ReverseMap();
        CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
    }
}