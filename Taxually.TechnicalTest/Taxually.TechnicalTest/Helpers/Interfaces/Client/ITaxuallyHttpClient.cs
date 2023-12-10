namespace Taxually.TechnicalTest.Helpers.Interfaces.Client
{
    public interface ITaxuallyHttpClient<T>
    {
        Task PostAsync(string url, T request);
    }
}
