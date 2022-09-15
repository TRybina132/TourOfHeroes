using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Messaging.Producers
{
    //  💫 AMQP (advanced message query protocol) - messaging protocol
    //          that enables us sending messages in async manner, useful
    //          in microservices to communicate between them ✨
    //
    //  💞 RabbitMQ - cool tool that supports AMQP, to run RabbitMQ we need
    //      create container that will provide us routing between queues 🦖
    //
    //  🌈 So we're sending messages to exchange that will route
    //          message to queue(temporary storage for messages) and
    //          it sends message to subscribed clients 💖
    public class HeroMessageProducer : IMessageProducer, IDisposable
    {
        // 🐐 ATTETION! 🐐
        //      Always provide IDisposable pattern to whole class that uses
        //      services that will have connections and etc, and don't use 
        //      using statement with them, dispose them in type's method
        //      cause we need this connection to recieve messages
        private IConnection? connection;
        private IModel? channel;

        public void Dispose()
        {
            connection?.Dispose();
            channel?.Dispose();
        }

        public void SendMessage<T>(T message)
        {
            //  ᓚᘏᗢ Setting up RabbitMQ server
            ConnectionFactory factory = new ConnectionFactory { HostName = "localhost" };
            connection = factory.CreateConnection();

            channel = connection.CreateModel();

            //  ᓚᘏᗢ Declare queue of messages
            channel.QueueDeclare("heroes", 
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string json = JsonConvert.SerializeObject(message);
            byte[] body = Encoding.UTF8.GetBytes(json);

            //  ᓚᘏᗢ Sending message
            channel.BasicPublish(exchange: "", routingKey: "heroes", body: body);
        }
    }
}
