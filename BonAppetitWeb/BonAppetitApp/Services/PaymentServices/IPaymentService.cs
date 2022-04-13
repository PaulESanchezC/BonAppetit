using Models.PaymentModels;
using Models.ResponseModels;

namespace Services.PaymentServices;

public interface IPaymentService
{
    Task<Response<Payment>> CreatePaymentSessionAsync(PaymentCreateVm paymentInformation);
    Task<Response<Payment>> ConfirmPaymentAsync(Payment paymentInformation);
}