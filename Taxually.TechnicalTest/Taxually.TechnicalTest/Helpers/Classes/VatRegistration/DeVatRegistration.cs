using Taxually.TechnicalTest.Helpers.Interfaces.QueueClient;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.XmlBuilder;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.VatRegistration
{
    public class DeVatRegistration : IVatRegistration<VatRegistrationModel>
    {
        private readonly ITaxuallyQueueClient<string> _queueClient;
        private readonly IXmlBuilder<VatRegistrationModel> _xmlBuilder;

        public DeVatRegistration(ITaxuallyQueueClient<string> queueClient, IXmlBuilder<VatRegistrationModel> xmlBuilder)
        {
            _queueClient = queueClient;
            _xmlBuilder = xmlBuilder;
        }

        public async Task Register(VatRegistrationModel registrationModel)
        {
            var xml = _xmlBuilder.BuildXml(registrationModel);
            // Queue xml doc to be processed
            await _queueClient.EnqueueAsync("vat-registration-xml", xml);
        }
    }
}
