using MessageProvider.Enums;
using MessageProvider.Interfaces;

namespace MessageProvider.Messages
{

    public class MessageContext
    {
        public MessageEnum MessageType { get; set; }
        public IMessage Message { get; set; }
    }
}
