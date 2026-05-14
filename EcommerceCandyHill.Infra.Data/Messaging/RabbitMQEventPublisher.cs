// Infrastructure/Messaging/RabbitMQEventPublisher.cs
using EcommerceCandyHill.Application.Messaging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EcommerceCandyHill.Infra.Data.Messaging
{
    public class RabbitMQEventPublisher : IEventPublisher
    {
        private readonly IConnection _connection;
        private readonly IChannel _channel;

        public RabbitMQEventPublisher()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
            _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();
        }

        public async Task PublishAsync<T>(T @event, string queueName) where T : class
        {
            await _channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            var message = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(message);

            await _channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: queueName,
                body: body
            );
        }
    }
}