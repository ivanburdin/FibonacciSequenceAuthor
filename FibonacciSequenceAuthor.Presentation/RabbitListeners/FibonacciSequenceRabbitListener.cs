using System.Text.Json;
using FibonacciSequenceAuthor.Presentation.RabbitListeners.Contracts;
using FibonacciSequenceAuthor.Presentation.RabbitListeners.Converters;
using FibonacciSequenceAuthor.Presentation.RabbitListeners.Options;
using MediatR;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FibonacciSequenceAuthor.Presentation.RabbitListeners
{
    public class FibonacciSequenceRabbitListener
    {
        private readonly IModel _channel;
        private readonly IConnection _connection;
        private readonly IMediator _mediator;
        private readonly RabbitOptions _options;

        private readonly ILogger<FibonacciSequenceRabbitListener> _logger;

        public FibonacciSequenceRabbitListener(IMediator mediator, RabbitOptions options,
            ILogger<FibonacciSequenceRabbitListener> logger)
        {
            _mediator = mediator;
            _options = options;
            _logger = logger;

            var factory = new ConnectionFactory
            {
                HostName = _options.Host,
                UserName = _options.User,
                Password = _options.Password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Register()
        {
            _channel.QueueDeclare(_options.Queue,
                false,
                false,
                false,
                null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (_, ea) =>
            {
                var message = JsonSerializer.Deserialize<ContinueFibonacciSequenceQueueExternal>(ea.Body.ToArray());

                var command = message.ToCommand();

                await _mediator.Send(command);
            };
            _channel.BasicConsume(_options.Queue, true, consumer);
        }

        // will execute on ctrl + c
        public void Deregister()
        {
            _channel.Close();
            _connection.Close();

            _logger.LogInformation("Rabbit deregister executed");
        }
    }
}