using Taxually.TechnicalTest.Helpers.Interfaces.HttpClient;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.VatRegistration
{
    public class GbVatRegistration : IVatRegistration <VatRegistrationModel>
    {
        private readonly ITaxuallyHttpClient<VatRegistrationModel> _httpClient;

        public GbVatRegistration(ITaxuallyHttpClient<VatRegistrationModel> httpClient)
        {
            _httpClient = httpClient;
        }

        public async void Register(VatRegistrationModel registrationModel)
        {
                //unsure of PostAsync real body but if it was known I would add some sort of check if registration was successful and return result.
                await _httpClient.PostAsync("https://api.uktax.gov.uk", registrationModel);
        }
    }
}
