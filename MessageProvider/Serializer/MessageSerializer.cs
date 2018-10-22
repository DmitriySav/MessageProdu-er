using MessageProvider.Enums;
using MessageProvider.Interfaces;
using MessageProvider.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageProvider.Serializer
{
    public class JsonMessageSerializer : IMessageSerializer
    {
        public string SerializeMessage(IMessage message, MessageEnum messageType)
        {
            return JsonConvert.SerializeObject(new MessageContext
            {
                MessageType = messageType,
                Message = message
            });
        }

        public (MessageEnum messageType, string messageBody) ParseMessageContext(string messageContext)
        {
            var deserialized = JObject.Parse(messageContext);
            var messageType = (MessageEnum)(int)deserialized["MessageType"];
            var message = deserialized["Message"].ToString();

            return (messageType, message);
        }

        public T DeserializeMessage<T>(string messageBody)
        {
            return JsonConvert.DeserializeObject<T>(messageBody);
        }
    }
}
