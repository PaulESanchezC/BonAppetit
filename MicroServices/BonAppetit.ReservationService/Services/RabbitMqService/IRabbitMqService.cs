using Microsoft.Extensions.Hosting;
using Models.EmailModels;

namespace Services.RabbitMqService;

public interface IRabbitMqService
{
    void SendEmailMessage(List<Email> Email);
}