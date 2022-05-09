using Models.MessageQueueModels.PaymentSuccessMessageModels;

namespace Services.RabbitMqSender;

public interface IPaymentMessageSender
{
    void CreateConnection();
    bool ConnectionExists();
    void SendPaymentSuccessMessage(PaymentSuccessMessage message);
}