using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.PaymentModels;
using Models.ResponseModels;
using Models.StripeSessionModels;

namespace Services.PaymentServices;

public interface IPaymentServices
{
    Task<Response<StripeSession>> CreateStripePaymentSessionAsync(StripeSessionCreate paymentInformation,
        CancellationToken cancellationToken);

    Task<Response<PaymentDto>> ConfirmPaymentIsSuccessful(PaymentCreate paymentToConfirm, PaymentMessage message,
        CancellationToken cancellationToken);

    Task<Response<PaymentDto>> GetPaymentInformation(string paymentId, CancellationToken cancellationToken);
}