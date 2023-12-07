using Taxually.TechnicalTest.Helpers.Interfaces.QueueClient;

namespace Taxually.TechnicalTest.Helpers.Classes.QueueClient
{
    public class CsvTaxuallyQueueClient : ITaxuallyQueueClient<byte[]>
    {
        public Task EnqueueAsync(string queueName, byte[] payload)
        {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}
