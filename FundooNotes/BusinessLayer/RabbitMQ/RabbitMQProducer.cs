using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace BusinessLayer.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public async Task SendMessage<T>(T message) // ✅ FIXED
        {
            Console.WriteLine("Inside RabbitMQ Producer"); // DEBUG

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "FundooQueue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "FundooQueue",
                body: body
            );

            Console.WriteLine("=========Message published to queue========="); // DEBUG
        }
    }
}