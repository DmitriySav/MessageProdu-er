using System;
using System.Collections.Generic;
using MessageProvider.Enums;
using MessageProvider.Messages;
using MessageProvider.Serializer;

namespace MessageProducer.Condition
{
   public static class MessageGeneratorCondition
    {
       public static Dictionary<MessageEnum, Func<int, IMessageSerializer,string>> condition = new Dictionary<MessageEnum, Func<int, IMessageSerializer, string>>
        {
            {MessageEnum.UserMessage, (id, serializer) =>
            {
                UserMessage userMessage = new UserMessage
                {
                    FacilityId = id,
                    FacilityName = "User",
                    Action = "jump"
                };
                 return serializer.SerializeMessage(userMessage, MessageEnum.UserMessage);               
            }},
            {
                MessageEnum.UmpireMessage, (id, serializer) =>
                {
                    UmpireMessage umpireMessage = new UmpireMessage
                    {
                        FacilityId = id,
                        FacilityName = "Umpire",
                        Activity = "whistle",
                        CreatedAtUtc = DateTime.Now
                    };
                    return serializer.SerializeMessage(umpireMessage, MessageEnum.UmpireMessage);
                }
            },
            {MessageEnum.CoachMessage, (id, serializer) =>
            {
                CoachMessage coachMessage = new CoachMessage
                {
                    UserId = id,
                    UserActivity = "treining",
                    CreatedAtUtc = DateTime.Now
                };
                return serializer.SerializeMessage(coachMessage, MessageEnum.CoachMessage);
            }}

        };

        
    }
}
