using System.Text;
using Microsoft.Extensions.Options;
using Models.Options;
using Models.PaymentMessageModels;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Services.RabbitMqSender;

public class PaymentMessageSender : IPaymentMessageSender
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private IConnection _connection;

    public PaymentMessageSender(IOptions<RabbitMqOptions> options)
    {
        _rabbitMqOptions = options.Value;
    }

    public void SendMessage(PaymentSuccessMessage message, string queueName)
    {
        var factory = new ConnectionFactory()
        {
            HostName = _rabbitMqOptions.Hostname,
            UserName = _rabbitMqOptions.Username,
            Password = _rabbitMqOptions.Password
        };
        _connection = factory.CreateConnection();

        using var channel = _connection.CreateModel();
        channel.QueueDeclare(queueName, false, false, false);
        var jsonContent = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(jsonContent);
        channel.BasicPublish("",queueName,null,body);
    }
}