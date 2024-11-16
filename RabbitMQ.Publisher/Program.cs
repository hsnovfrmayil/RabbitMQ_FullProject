using System.Text;
using RabbitMQ.Client;


//Baglanti qurmaq 
ConnectionFactory factory = new();
factory.Uri = new("...");


//baglantini aktivlesdirmek ve kanal acmaq
using IConnection connection =factory.CreateConnection();
using IModel channel = connection.CreateModel();


//Queue yaratmaq
channel.QueueDeclare(queue: "example-queue",exclusive: false );


//Queue mesaj gondermek
//byte[] message = Encoding.UTF8.GetBytes("hELLO kele");
//channel.BasicPublish(exchange: "",routingKey: "example-queue",body: message);


for(int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes("hELLO kele"+i);
    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);
}


Console.Read(); 