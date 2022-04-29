using AutoMapper;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.PaymentModels;

namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<PaymentBase, PaymentDto>().ReverseMap();
        CreateMap<PaymentCreate, PaymentBase>().ReverseMap();
        CreateMap<PaymentCreate, PaymentDto>().ReverseMap();

        CreateMap<PaymentMessage, PaymentSuccessMessage>().ReverseMap();
    }
}