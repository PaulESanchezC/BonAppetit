using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.MessageQueueModels.ReservationSuccessModels;
using Models.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.MessageQueueHandlerService;
using StaticData;

namespace Services.RabbitMqSender;

public class ReservationMessageSender : BackgroundService
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private readonly IMessageQueueHandler _messageQueueHandler;
    private IConnection _connection;
    private IModel _channel;

    public ReservationMessageSender(IOptions<RabbitMqOptions> options, IMessageQueueHandler messageQueueHandler)
    {
        _messageQueueHandler = messageQueueHandler;
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
        _channel.ExchangeDeclare(RabbitMqConstants.ExchangeReservationSuccess,ExchangeType.Fanout);
        var queueName = _channel.QueueDeclare().QueueName;

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (channel, message)  =>
        {
            var messageContent = Encoding.UTF8.GetString(message.Body.ToArray());
            var reservationSuccessMessage = JsonConvert.DeserializeObject<ReservationSuccessMessage>(messageContent);

            await _messageQueueHandler.ReservationSuccessMessageHandlerAsync(reservationSuccessMessage, cancellationToken);

            _channel.BasicAck(message.DeliveryTag, false);
        };
        _channel.BasicConsume(RabbitMqConstants.QueuePaymentSuccess, false, consumer);
        return Task.CompletedTask;
    }
}