using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Services.Repository.ReservationServices;

namespace Services.MessageQueueHandlerService;

public class MessageQueueHandler : IMessageQueueHandler
{
    private readonly IReservationService _reservation;
    public MessageQueueHandler(IReservationService reservation)
    {
        _reservation = reservation;
    }

    public async Task PaymentSuccessMessageHandlerAsync(PaymentSuccessMessage paymentSuccess, CancellationToken cancellationToken)
    {
        var reservationCreate = paymentSuccess.ReservationCreate;
        var request = await _reservation.MakeReservationAsync(reservationCreate, cancellationToken);
    }
}