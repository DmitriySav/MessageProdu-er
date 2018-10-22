using System;
using MessageProvider.Interfaces;

namespace MessageProvider.Messages
{
    [Serializable]
    public class CoachMessage:IMessage
    {
        public int UserId { get; set; }
        public string UserActivity { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
