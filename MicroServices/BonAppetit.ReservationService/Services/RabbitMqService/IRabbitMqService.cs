using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.ReservationModels;

namespace Services.RabbitMqService;

public interface IRabbitMqService
{
    void SendReservationSuccessMessage(PaymentSuccessMessage paymentSuccessMessage, ReservationDto reservation);
}