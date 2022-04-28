using AutoMapper;
using Models.ReservationModels;
using Models.ViewModels;

namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<ReservationCreate, ConfirmReservationVm >().ReverseMap();
    }
}