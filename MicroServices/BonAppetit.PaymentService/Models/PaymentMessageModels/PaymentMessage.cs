using Models.PaymentModels;
using Models.ResponseModels;

namespace Models.PaymentMessageModels;

public class PaymentMessage
{
    public Response<PaymentDto> Message { get; set; }
}