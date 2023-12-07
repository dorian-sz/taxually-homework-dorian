namespace Taxually.TechnicalTest.Helpers.Interfaces.QueueClient
{
    public interface ITaxuallyQueueClient <T>
    {
        Task EnqueueAsync(string queueName, T payload);
    }
}
