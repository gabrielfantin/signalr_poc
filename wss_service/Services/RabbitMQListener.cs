using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace wss.Services;

public class RabbitMQListener(IConnectionFactory connectionFactory) : BackgroundService
{
    private readonly IConnectionFactory _connectionFactory = connectionFactory;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        Console.WriteLine("Listening the broker for messages");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, args) =>
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"Received message from broker: {message}");
        };

        channel.BasicConsume("default", true, consumer);

        // Keep the task long running if it's not cancelled from outside
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(5000, stoppingToken);
        }
    }
}
