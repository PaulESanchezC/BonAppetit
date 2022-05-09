using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.ReservationModels;

namespace Services.RabbitMqService;

public interface IRabbitMqService
{
    void SendProductionQueueMessage(PaymentSuccessMessage paymentSuccessMessage, ReservationDto reservation);
}