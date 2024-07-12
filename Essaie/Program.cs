using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare(queue: "test-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

var body = Encoding.UTF8.GetBytes("Hello RabbitMQ!");
channel.BasicPublish(exchange: "", routingKey: "bankingsystem-queue", basicProperties: null, body: body);

Console.WriteLine(" [x] Sent 'Hello RabbitMQ!'");
