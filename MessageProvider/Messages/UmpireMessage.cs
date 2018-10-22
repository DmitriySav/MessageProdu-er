using System;
using MessageProvider.Interfaces;

namespace MessageProvider.Messages
{
    [Serializable]
    public class UmpireMessage:IMessage
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string Activity { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
