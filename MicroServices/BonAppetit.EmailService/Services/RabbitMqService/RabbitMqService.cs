using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.MessageQueueModels.ReservationSuccessModels;
using Models.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.EmailServices;
using StaticData;


namespace Services.RabbitMqService;

public class RabbitMqService : BackgroundService
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private IConnection _connection;
    private IModel _channel;
    private readonly IMailJetEmailSender _emailSender;
    public RabbitMqService(IOptions<RabbitMqOptions> options, IMailJetEmailSender emailSender)
    {
        _emailSender = emailSender;
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
        _channel.QueueDeclare(RabbitMqConstants.QueueReservationSuccess, false, false, false);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (channel, message) =>
        {
            var messageContent = Encoding.UTF8.GetString(message.Body.ToArray());
            var reservationSuccessMessage = JsonConvert.DeserializeObject<ReservationSuccessMessage>(messageContent);
            Console.WriteLine("**********************************************************************************");
            reservationSuccessMessage.Emails.ForEach(email => Console.WriteLine(email.Data));
            _emailSender.MailJetMailSenderAsync(reservationSuccessMessage.Emails, cancellationToken).GetAwaiter().GetResult();
            _channel.BasicAck(message.DeliveryTag, false);
        };
        _channel.BasicConsume(RabbitMqConstants.QueueReservationSuccess, false, consumer);
        return Task.CompletedTask;
    }
}