using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.PaymentModels;

namespace Services.MessageQueueHandlerService;

public interface IMessageQueueHandler
{
    Task PaymentSuccessMessageHandlerAsync(PaymentSuccessMessage paymentSuccess, CancellationToken cancellationToken);
}