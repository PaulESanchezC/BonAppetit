using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.PaymentModels;
using Models.ReservationModels;

namespace Services.MessageQueueHandlerService;

public interface IMessageQueueHandler
{
    Task<ReservationDto> PaymentSuccessMessageHandlerAsync(PaymentSuccessMessage paymentSuccess, CancellationToken cancellationToken);
}