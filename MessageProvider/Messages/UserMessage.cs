using System;
using MessageProvider.Interfaces;

namespace MessageProvider.Messages
{
    [Serializable]
    public class UserMessage:IMessage
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string Action { get; set; }
    }
}
