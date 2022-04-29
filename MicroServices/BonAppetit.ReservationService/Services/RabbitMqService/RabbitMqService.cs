﻿using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.MessageQueueModels.ReservationSuccessModels;
using Models.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.MessageQueueHandlerService;
using StaticData;

namespace Services.RabbitMqService;

public class RabbitMqService : BackgroundService , IRabbitMqService
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private readonly IMessageQueueHandler _messageQueueHandler;
    private IConnection _connection;
    private IModel _channel;

    public RabbitMqService(IConnection connection, IOptions<RabbitMqOptions> options, IMessageQueueHandler messageQueueHandler)
    {
        _connection = connection;
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

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (channel, message) =>
        {
            var messageContent = Encoding.UTF8.GetString(message.Body.ToArray());
            var paymentSuccessMessage = JsonConvert.DeserializeObject<PaymentSuccessMessage>(messageContent);

            await _messageQueueHandler.PaymentSuccessMessageHandlerAsync(paymentSuccessMessage, cancellationToken);
            _channel.BasicAck(message.DeliveryTag,false);
        };
        _channel.BasicConsume(RabbitMqConstants.QueuePaymentSuccess, false, consumer);
        return Task.CompletedTask;
    }

    public void SendReservationSuccessMessage(ReservationSuccessMessage message)
    {
        var factory = new ConnectionFactory()
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
}