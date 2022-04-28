using Models.PaymentMessageModels;

namespace Services.RabbitMqSender;

public interface IPaymentMessageSender
{
    void SendMessage(PaymentMessage message, string queueName);
}