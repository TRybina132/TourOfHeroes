namespace Messaging.Producers
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
