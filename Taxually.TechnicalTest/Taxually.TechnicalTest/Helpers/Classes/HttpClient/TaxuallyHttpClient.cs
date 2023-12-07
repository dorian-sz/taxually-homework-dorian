using Taxually.TechnicalTest.Helpers.Interfaces.HttpClient;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.HttpClient
{
    public class TaxuallyHttpClient : ITaxuallyHttpClient<VatRegistrationModel>
    {
        public Task PostAsync(string url, VatRegistrationModel request)
        {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}
