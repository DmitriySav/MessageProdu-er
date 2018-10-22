using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace MessageProducer.AzureQueueProducer
{
    public class AzureQueueProducer : IAzureQueueProducer
    {
        private CloudQueue _queue;
        public AzureQueueProducer(string connectionString, string itemReference)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            _queue = queueClient.GetQueueReference(itemReference);
        }

        public void AddItem(string item)
        {
            _queue.CreateIfNotExists();
            _queue.AddMessage(new CloudQueueMessage(item));
        }

        public async Task AddItemAsync(string item)
        {
            await _queue.CreateIfNotExistsAsync();
            await _queue.AddMessageAsync(new CloudQueueMessage(item));
        }
    }
}