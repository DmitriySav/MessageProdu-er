using System;
using System.Linq;
using System.Threading.Tasks;
using AzureConfig.Constant;
using AzureConfig.Context;
using AzureConfig.Interfaces;
using AzureConfig.Repository;
using MessageProducer.AzureQueueProducer;
using MessageProducer.Condition;
using MessageProvider.Enums;
using MessageProvider.Serializer;

namespace MessageProducer
{
    class Program
    {
        static void Main()
        {
            ConfigContext dbcontext = new ConfigContext(Constants.DbConnectionName);
            IConnectionStringRepo repo = new ConnectionStringRepo(dbcontext);

            var connectionStrings = repo.GetAll();
            var connString = connectionStrings.SingleOrDefault(x => x.Environment == EnvironmentEnum.Development);

            IAzureQueueProducer queueProducer = new AzureQueueProducer.AzureQueueProducer(connString?.Value, connString?.Name);

            IMessageSerializer serializer = new JsonMessageSerializer();

            PushToQueue(queueProducer, serializer).Wait();


        }

        private static async Task PushToQueue(IAzureQueueProducer queue, IMessageSerializer serializer)
        {
            Random rnd = new Random();
            var index = 0;
            while (true)
            {

                var messageTypesCount = Enum.GetValues(typeof(MessageEnum)).Length;
                int messNuber = rnd.Next(messageTypesCount);
                MessageEnum messageEnum = (MessageEnum)messNuber;
                var message = MessageGeneratorCondition.condition[messageEnum](index, serializer);
                Console.WriteLine(message);
                await queue.AddItemAsync(message);
                await Task.Delay(4000);
                index++;
            }
        }
    }
}

