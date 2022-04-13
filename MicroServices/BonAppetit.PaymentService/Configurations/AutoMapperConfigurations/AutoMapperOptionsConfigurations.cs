using AutoMapper;
using Models.PaymentModels;

namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<PaymentBase, PaymentDto>().ReverseMap();
        CreateMap<PaymentCreate, PaymentBase>().ReverseMap();
        CreateMap<PaymentCreate, PaymentDto>().ReverseMap();
    }
}