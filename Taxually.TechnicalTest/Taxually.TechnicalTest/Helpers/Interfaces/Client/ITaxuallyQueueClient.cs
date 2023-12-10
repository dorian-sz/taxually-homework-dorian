namespace Taxually.TechnicalTest.Helpers.Interfaces.Client
{
    public interface ITaxuallyQueueClient<T>
    {
        Task EnqueueAsync(string queueName, T payload);
    }
}
