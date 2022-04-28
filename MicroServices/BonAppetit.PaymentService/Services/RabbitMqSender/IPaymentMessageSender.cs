using Models.PaymentMessageModels;

namespace Services.RabbitMqSender;

public interface IPaymentMessageSender
{
    void SendMessage(PaymentSuccessMessage message, string queueName);
}