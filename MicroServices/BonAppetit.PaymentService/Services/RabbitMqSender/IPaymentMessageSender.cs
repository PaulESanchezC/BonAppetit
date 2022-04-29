using Models.MessageQueueModels.PaymentSuccessMessageModels;

namespace Services.RabbitMqSender;

public interface IPaymentMessageSender
{
    void SendPaymentSuccessMessage(PaymentSuccessMessage message);
}