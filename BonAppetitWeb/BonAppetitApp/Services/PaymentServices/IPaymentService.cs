using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.PaymentModels;
using Models.ResponseModels;
using Models.StripeSessionModels;

namespace Services.PaymentServices;

public interface IPaymentService
{
    Task<Response<StripeSession>> CreatePaymentSessionAsync(StripeSessionCreate paymentInformation);
    Task<Response<Payment>> ConfirmPaymentAsync(PaymentCreateVm paymentInformation, PaymentMessage message);
}