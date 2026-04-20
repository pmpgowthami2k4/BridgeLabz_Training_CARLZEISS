using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace CollaboratorService.Infrastructure.RabbitMQ
{
    public class RabbitMqPublisher
    {
        private readonly IConfiguration _config;

        public RabbitMqPublisher(IConfiguration config)
        {
            _config = config;
        }

        public async Task PublishAsync(string queueName, object message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _config["RabbitMQ:Host"] ?? "localhost"
            };

            await using var connection =
                await factory.CreateConnectionAsync();

            await using var channel =
                await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(
                JsonSerializer.Serialize(message));

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: queueName,
                body: body);
        }
    }
}