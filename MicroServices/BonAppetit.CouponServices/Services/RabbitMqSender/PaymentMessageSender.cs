using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StaticData;

namespace Services.RabbitMqSender;

public class PaymentMessageSender : BackgroundService
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private IConnection _connection;
    private IModel _channel;
    
    public PaymentMessageSender(IOptions<RabbitMqOptions> options)
    {
        _rabbitMqOptions = options.Value;
    }
    
    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var factory = new ConnectionFactory()
        {
            HostName = _rabbitMqOptions.Hostname,
            UserName = _rabbitMqOptions.Username,
            Password = _rabbitMqOptions.Password
        };

        _connection = factory.CreateConnection();

        _channel = _connection.CreateModel();
        _channel.QueueDeclare(RabbitMqConstants.QueuePaymentSuccess, false, false, false);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (channel, message) =>
        {
            var messageContent = Encoding.UTF8.GetString(message.Body.ToArray());
            var paymentSuccessMessage = JsonConvert.DeserializeObject<PaymentSuccessMessage>(messageContent);
            //TODO: Add message handler for  paymentSuccessMessage
            _channel.BasicAck(message.DeliveryTag, false);
        };
        _channel.BasicConsume(RabbitMqConstants.QueuePaymentSuccess, false, consumer);
        return Task.CompletedTask;
    }
}