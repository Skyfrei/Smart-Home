using System.Text;
using System.Text.Json;
using NotificationService.Dtos;
using RabbitMQ.Client;

namespace NotificationService.AsyncCommunication
{
    public class MessageBus : IMessageBus
    {
        private IConfiguration _config;
        private IConnection _connection;
        private IModel _channel;

        public MessageBus(IConfiguration config)
        {
            _config = config;
            var factory = new ConnectionFactory()
            {
                HostName = _config["RabbitMQHost"],
                Port = int.Parse(_config["RabbitMQPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += ShutDown_RabbitMQ;
                Console.WriteLine("Connected to msg bus.");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Something went incredibly wrong -----> {e}");
            }
        }

        private void SendMessage(string msg)
        {
            var body = Encoding.UTF8.GetBytes(msg);

            _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);

            Console.WriteLine($"-----> Send the {msg}");
        }

        private void ShutDown_RabbitMQ(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("Rabbit connection died.");
        }

        public void PublishNotification(NotificationPublish publishNotification)
        {
            var message = JsonSerializer.Serialize(publishNotification);

            if (_connection.IsOpen)
            {
                Console.WriteLine("Rabit Conn open.");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("Rabbit connection isn't open.");
            }
        }
        
        public void DisposeMessage()
        {
            Console.WriteLine("MessageBus disposed");
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
    }
}