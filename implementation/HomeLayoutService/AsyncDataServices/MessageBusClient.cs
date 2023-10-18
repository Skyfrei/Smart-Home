using System.Text;
using System.Text.Json;
using HomeLayoutService.Dto;
using RabbitMQ.Client;

namespace HomeLayoutService.AsyncDataService
{
    public class MessageBusClient : IMessageBusClient
    {
        private IConfiguration _config;
        private IConnection _connection;
        private IModel _channel;

        public MessageBusClient(IConfiguration config)
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
        public void PublishNewRoom(RoomPublishedDto roomDto)
        {
            var message = JsonSerializer.Serialize(roomDto);

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
        private void SendMessage(string messageJson)
        {
            var body = Encoding.UTF8.GetBytes(messageJson);

            _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);

            Console.WriteLine($"-----> Send the {messageJson}");
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

        private void ShutDown_RabbitMQ(object sender, ShutdownEventArgs args)
        {
            Console.WriteLine("Rabbit connection died.");
        }
    }
}