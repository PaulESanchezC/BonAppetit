using System.Text;
using Microsoft.Extensions.Options;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using StaticData;

namespace Services.RabbitMqSender;

public class PaymentMessageSender : IPaymentMessageSender
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private IConnection _connection;

    public PaymentMessageSender(IOptions<RabbitMqOptions> options)
    {
        _rabbitMqOptions = options.Value;
    }

    public void SendPaymentSuccessMessage(PaymentSuccessMessage message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = _rabbitMqOptions.Hostname,
            UserName = _rabbitMqOptions.Username,
            Password = _rabbitMqOptions.Password
        };
        _connection = factory.CreateConnection();

        using var channel = _connection.CreateModel();
        channel.QueueDeclare(RabbitMqConstants.QueuePaymentSuccess, false, false, false);
        var jsonContent = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(jsonContent);
        channel.BasicPublish("", RabbitMqConstants.QueuePaymentSuccess, null,body);
    }
}