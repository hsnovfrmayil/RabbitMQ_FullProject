using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

//Baglanti qurmaq 
ConnectionFactory factory = new();
factory.Uri = new("...");


//baglantini aktivlesdirmek ve kanal acmaq
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();


//Queue yaratmaq
channel.QueueDeclare(queue: "example-queue", exclusive: false);


//Queue mesaj gondermek
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-queue",false,consumer);
consumer.Received += (sender, e) =>
{
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
};


Console.Read();
