using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.EmailModels;
using Models.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using StaticData;

namespace Services.RabbitMqService;

public class RabbitMqService : BackgroundService , IRabbitMqService
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private IConnection _connection;

    public RabbitMqService(IConnection connection, IOptions<RabbitMqOptions> options)
    {
        _connection = connection;
        _rabbitMqOptions = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }

    public void SendReservationSuccessMessage(List<Email> Email)
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