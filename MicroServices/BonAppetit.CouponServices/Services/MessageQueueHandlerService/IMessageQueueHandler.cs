using Models.MessageQueueModels.ReservationSuccessModels;
using Models.PaymentModels;
using Models.ReservationModels;

namespace Services.MessageQueueHandlerService;

public interface IMessageQueueHandler
{
    Task ReservationSuccessMessageHandlerAsync(ReservationSuccessMessage reservationSuccessMessage, CancellationToken cancellationToken);
}