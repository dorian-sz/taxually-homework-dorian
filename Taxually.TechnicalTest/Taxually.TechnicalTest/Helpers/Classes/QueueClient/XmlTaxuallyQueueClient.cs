using Taxually.TechnicalTest.Helpers.Interfaces.QueueClient;

namespace Taxually.TechnicalTest.Helpers.Classes.QueueClient
{
    public class XmlTaxuallyQueueClient : ITaxuallyQueueClient<string>
    {
        public Task EnqueueAsync(string queueName, string payload)
        {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}
