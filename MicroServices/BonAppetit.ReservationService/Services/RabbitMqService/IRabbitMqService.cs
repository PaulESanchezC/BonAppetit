using Microsoft.Extensions.Hosting;
using Models.EmailModels;
using Models.MessageQueueModels.ReservationSuccessModels;

namespace Services.RabbitMqService;

public interface IRabbitMqService
{
    void SendReservationSuccessMessage(ReservationSuccessMessage message);
}