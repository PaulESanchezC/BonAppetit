using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.EmailModels;
using Models.Options;
using RabbitMQ.Client;

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

    public void SendEmailMessage(List<Email> Email)
    {
        throw new NotImplementedException();
    }
}