using Models.PaymentModels;
using Models.ResponseModels;

namespace Services.PaymentServices;

public interface IPaymentServices
{
    Task<Response<PaymentDto>> CreateStripePaymentSessionAsync(PaymentCreate paymentInformation,
        CancellationToken cancellationToken);

    Task<Response<PaymentDto>> ConfirmPaymentIsSuccessful(PaymentDto paymentToConfirm,
        CancellationToken cancellationToken);
}