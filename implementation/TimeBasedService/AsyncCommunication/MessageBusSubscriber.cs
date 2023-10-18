using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TimeBasedService.AsyncCommunication
{
    public class MessageBusSubscriber : BackgroundService
    {
        private IConfiguration _config;
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;

        public MessageBusSubscriber(IConfiguration config)
        {
            _config = config;
            Initialize();
        }

        private void Initialize()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _config["RabbitMQHost"],
                Port = int.Parse(_config["RabbitMQPort"])
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(_queueName, "trigger", "");

            Console.WriteLine("---Listening to the bus.");

            _connection.ConnectionShutdown += ShutDown;
        }
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                Console.WriteLine("---> Event received!");

                var body = ea.Body;
                var serviceMessage = Encoding.UTF8.GetString(body.ToArray());
            };
            _channel.BasicConsume(_queueName, true, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
            base.Dispose();
        }

        private void ShutDown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("---> Stopped listening. 'MessageBusSub'");
        }
    }
}