using System.Text;
using Taxually.TechnicalTest.Helpers.Classes.QueueClient;
using Taxually.TechnicalTest.Helpers.Interfaces.QueueClient;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.VatRegistration
{
    public class FrVatRegistration : IVatRegistration<VatRegistrationModel>
    {
        private readonly ITaxuallyQueueClient<byte[]> _queueClient;

        public FrVatRegistration(ITaxuallyQueueClient<byte[]> queueClient)
        {
            _queueClient = queueClient;
        }

        public async void Register(VatRegistrationModel registrationModel)
        {
            var stringBuilder = StringBuilder(registrationModel.CompanyName, registrationModel.CompanyId);
            var csv = CsvBuilder(stringBuilder);
            // Queue file to be processed
            await _queueClient.EnqueueAsync("vat-registration-csv", csv);
        }

        private StringBuilder StringBuilder(string comapnyName, string companyId)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{comapnyName}{companyId}");

            return csvBuilder;
        }

        private byte[] CsvBuilder (StringBuilder stringBuilder)
        {
            return Encoding.UTF8.GetBytes(stringBuilder.ToString());
        }
    }
}
