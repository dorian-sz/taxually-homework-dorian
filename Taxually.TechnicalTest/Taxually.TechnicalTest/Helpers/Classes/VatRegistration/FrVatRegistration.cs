using Taxually.TechnicalTest.Helpers.Interfaces.CsvBuilder;
using Taxually.TechnicalTest.Helpers.Interfaces.QueueClient;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.VatRegistration
{
    public class FrVatRegistration : IVatRegistration<VatRegistrationModel>
    {
        private readonly ITaxuallyQueueClient<byte[]> _queueClient;
        private readonly ICsvBuilder _csvBuilder;
        public FrVatRegistration(ITaxuallyQueueClient<byte[]> queueClient, ICsvBuilder csvBuilder)
        {
            _queueClient = queueClient;
            _csvBuilder = csvBuilder;
        }

        public async Task Register(VatRegistrationModel registrationModel)
        {
            var csv = _csvBuilder.BuildCsv(registrationModel.CompanyName, registrationModel.CompanyId);
            // Queue file to be processed
            await _queueClient.EnqueueAsync("vat-registration-csv", csv);
        }
    }
}
