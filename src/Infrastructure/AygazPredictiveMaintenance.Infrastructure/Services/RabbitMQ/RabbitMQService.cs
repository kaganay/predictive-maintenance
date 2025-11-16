using System.Text;
using Newtonsoft.Json;
using PredictiveMaintenance.Domain.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PredictiveMaintenance.Infrastructure.Services.RabbitMQ;

public class RabbitMQService : IMessageQueueService, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _hostName;
    private readonly int _port;

    public RabbitMQService(string hostName = "localhost", int port = 5672)
    {
        _hostName = hostName;
        _port = port;
        
        var factory = new ConnectionFactory
        {
            HostName = hostName,
            Port = port,
            UserName = "guest",
            Password = "guest"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public async Task PublishAsync<T>(string queueName, T message) where T : class
    {
        _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;

        _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: properties, body: body);
        
        await Task.CompletedTask;
    }

    public async Task SubscribeAsync<T>(string queueName, Func<T, Task> handler) where T : class
    {
        _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var deserializedMessage = JsonConvert.DeserializeObject<T>(message);

            if (deserializedMessage != null)
            {
                await handler(deserializedMessage);
            }

            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        };

        _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        _channel?.Dispose();
        _connection?.Dispose();
    }
}


