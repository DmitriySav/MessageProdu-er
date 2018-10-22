using MessageProvider.Enums;
using MessageProvider.Interfaces;

namespace MessageProvider.Serializer
{
    public interface IMessageSerializer
    {
        string SerializeMessage(IMessage message, MessageEnum messageType);
        (MessageEnum messageType, string messageBody) ParseMessageContext(string messageContext);
        T DeserializeMessage<T>(string messageBody);
    }
}