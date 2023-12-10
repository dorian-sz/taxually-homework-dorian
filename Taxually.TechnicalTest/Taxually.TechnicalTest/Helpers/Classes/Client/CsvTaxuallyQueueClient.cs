using Taxually.TechnicalTest.Helpers.Interfaces.Client;

namespace Taxually.TechnicalTest.Helpers.Classes.Client
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
