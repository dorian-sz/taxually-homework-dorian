using Taxually.TechnicalTest.Helpers.Interfaces.Client;
using Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.VatRegistration
{
    public class GbVatRegistration : IVatRegistration<VatRegistrationModel>
    {
        private readonly ITaxuallyHttpClient<VatRegistrationModel> _httpClient;
        private readonly IModelPropertyChecker<VatRegistrationModel> _propertyChecker;

        public GbVatRegistration(ITaxuallyHttpClient<VatRegistrationModel> httpClient,
            IModelPropertyChecker<VatRegistrationModel> propertyChecker)
        {
            _httpClient = httpClient;
            _propertyChecker = propertyChecker;
        }

        public async Task<bool> Register(VatRegistrationModel registrationModel)
        {
            var isNotValidModel = _propertyChecker.AnyPropertiesDefault(registrationModel);
            if (isNotValidModel)
            {
                return false;
            }
            //unsure of PostAsync real body but if it was known I would add some sort of check if registration was successful and return result.
            await _httpClient.PostAsync("https://api.uktax.gov.uk", registrationModel);

            return true;
        }
    }
}
