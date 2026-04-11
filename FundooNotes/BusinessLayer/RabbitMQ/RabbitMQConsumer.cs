using System.Text;
using System.Text.Json;
using BusinessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelLayer.DTOs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMQConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public RabbitMQConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };

        var connection = await factory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync("FundooQueue", true, false, false, null);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (sender, args) =>
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            using var scope = _serviceProvider.CreateScope();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

            try
            {
                var email = JsonSerializer.Deserialize<EmailDTO>(message);

                if (email != null)
                {
                    await emailService.SendEmail(email.To, email.Subject, email.Body);
                }

                await channel.BasicAckAsync(args.DeliveryTag, false);
            }
            catch
            {
                await channel.BasicNackAsync(args.DeliveryTag, false, true);
            }
        };

        await channel.BasicConsumeAsync("FundooQueue", false, consumer);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}