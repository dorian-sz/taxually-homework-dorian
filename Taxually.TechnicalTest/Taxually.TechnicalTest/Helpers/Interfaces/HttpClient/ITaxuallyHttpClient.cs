namespace Taxually.TechnicalTest.Helpers.Interfaces.HttpClient
{
    public interface ITaxuallyHttpClient <T>
    {
        Task PostAsync(string url, T request);
    }
}
