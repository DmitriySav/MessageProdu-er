using System.Threading.Tasks;

namespace MessageProducer.AzureQueueProducer
{
    public interface IAzureQueueProducer
    {
        void AddItem(string item);
        Task AddItemAsync(string item);
    }
}
