using Taxually.TechnicalTest.Helpers.Interfaces.Client;
using Taxually.TechnicalTest.Helpers.Interfaces.FileBuilder;
using Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.VatRegistration
{
    public class FrVatRegistration : IVatRegistration<VatRegistrationModel>
    {
        private readonly ITaxuallyQueueClient<byte[]> _queueClient;
        private readonly ICsvBuilder _csvBuilder;
        private readonly IModelPropertyChecker<VatRegistrationModel> _propertyChecker;

        public FrVatRegistration(ITaxuallyQueueClient<byte[]> queueClient, 
            ICsvBuilder csvBuilder,
            IModelPropertyChecker<VatRegistrationModel> propertyChecker)
        {
            _queueClient = queueClient;
            _csvBuilder = csvBuilder;
            _propertyChecker = propertyChecker;
        }

        public async Task<bool> Register(VatRegistrationModel registrationModel)
        {
            var isNotValidModel = _propertyChecker.AnyPropertiesDefault(registrationModel);
            if (isNotValidModel)
            {
                return false;
            }
            var csv = _csvBuilder.BuildCsv(registrationModel.CompanyName, registrationModel.CompanyId);
            // Queue file to be processed
            await _queueClient.EnqueueAsync("vat-registration-csv", csv);

            return true;
        }
    }
}
