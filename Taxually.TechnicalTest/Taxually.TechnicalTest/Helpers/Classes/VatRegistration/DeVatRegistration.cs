using Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker;
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
        private readonly IModelPropertyChecker<VatRegistrationModel> _propertyChecker;
        public DeVatRegistration(ITaxuallyQueueClient<string> queueClient, 
            IXmlBuilder<VatRegistrationModel> xmlBuilder, 
            IModelPropertyChecker<VatRegistrationModel> propertyChecker)
        {
            _queueClient = queueClient;
            _xmlBuilder = xmlBuilder;
            _propertyChecker = propertyChecker;
        }

        public async Task<bool> Register(VatRegistrationModel registrationModel)
        {
            var isNotValidModel = _propertyChecker.AnyPropertiesDefault(registrationModel);
            if (isNotValidModel)
            {
                return false;
            }
            var xml = _xmlBuilder.BuildXml(registrationModel);
            // Queue xml doc to be processed
            await _queueClient.EnqueueAsync("vat-registration-xml", xml);

            return true;
        }
    }
}
