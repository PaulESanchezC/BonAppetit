using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.CouponModels;
using Models.EmailModels;
using Models.EmailModels.EmailDataModels;
using Models.EmailModels.EmailReservationModel;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.MessageQueueModels.ReservationSuccessModels;
using Models.Options;
using Models.ReservationModels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.MessageQueueHandlerService;
using StaticData;

namespace Services.RabbitMqService;

public class RabbitMqService : BackgroundService, IRabbitMqService
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private readonly IMessageQueueHandler _messageQueueHandler;
    private IConnection _connection;
    private IModel _channel;
    public RabbitMqService(IOptions<RabbitMqOptions> options, IMessageQueueHandler messageQueueHandler)
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
        _channel.QueueDeclare(RabbitMqConstants.QueuePaymentSuccess, false, false, false);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (channel, message) =>
        {
            var messageContent = Encoding.UTF8.GetString(message.Body.ToArray());
            var paymentSuccessMessage = JsonConvert.DeserializeObject<PaymentSuccessMessage>(messageContent);

            var reservationDto = _messageQueueHandler.PaymentSuccessMessageHandlerAsync(paymentSuccessMessage, cancellationToken).GetAwaiter().GetResult();

            SendReservationSuccessMessage(paymentSuccessMessage, reservationDto);

            _channel.BasicAck(message.DeliveryTag, false);
        };
        _channel.BasicConsume(RabbitMqConstants.QueuePaymentSuccess, false, consumer);
        return Task.CompletedTask;
    }

    public void SendReservationSuccessMessage(PaymentSuccessMessage paymentSuccessMessage, ReservationDto reservation)
    {
        var message = BuildReservationSuccessMessageModel(paymentSuccessMessage, reservation);

        var factory = new ConnectionFactory
        {
            HostName = _rabbitMqOptions.Hostname,
            UserName = _rabbitMqOptions.Username,
            Password = _rabbitMqOptions.Password
        };

        _connection = factory.CreateConnection();

        using var channel = _connection.CreateModel();
        channel.QueueDeclare(RabbitMqConstants.QueueReservationSuccess, false, false, false);
        var jsonContent = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(jsonContent);
        channel.BasicPublish("", RabbitMqConstants.QueueReservationSuccess, null, body);
    }
    public ReservationSuccessMessage BuildReservationSuccessMessageModel(PaymentSuccessMessage paymentSuccessMessage,
        ReservationDto reservation)
    {
        var clientEmailInformation = new EmailClient()
        {
            Coupon = new Coupon(),
            UserEmail = reservation.Email,
            UserFirstName = reservation.FirstName,
            UserLastName = reservation.LastName,
            UserPhone = reservation.Phone
        };
        var emailData = new EmailReservation()
        {
            DateOfReservation = reservation.DateOfReservation,
            StartTime = reservation.StartTime,
            ForHowMany = reservation.ForHowMany,
            OrderId = reservation.OrderId,
            RestaurantName = paymentSuccessMessage.RestaurantName,
            TableName = paymentSuccessMessage.TableName,
            Client = clientEmailInformation
        };
        var data = JsonConvert.SerializeObject(emailData);

        var clientEmail = new Email()
        {
            Action = EmailAction.ClientReservation,
            Data = data,
            Recipient = reservation.Email
        };
        var managerEmail = new Email()
        {
            Action = EmailAction.restaurantReservation,
            Data = data,
            Recipient = paymentSuccessMessage.RestaurantEmail
        };

        var emails = new List<Email>
        {
            clientEmail,
            managerEmail
        };

        var reservationSuccessMessage = new ReservationSuccessMessage 
        {
            Emails = emails
        };
        return reservationSuccessMessage;
    }
}