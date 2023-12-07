using Taxually.TechnicalTest.Helpers.Classes.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistrationFactory;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.VatRegistrationFactory
{
    public class VatRegistrationFactory : IVatRegistrationFactory<IVatRegistration<VatRegistrationModel>>
    {
        private readonly IEnumerable<IVatRegistration<VatRegistrationModel>> _vatRegistrations;

        public VatRegistrationFactory(IEnumerable<IVatRegistration<VatRegistrationModel>> vatRegistrations) 
        {
            _vatRegistrations = vatRegistrations;
        }

        public IVatRegistration<VatRegistrationModel>? GetRegistrationInstance(string countryCode)
        {
            return countryCode.ToUpper() switch
            {
                "GB" => _FindVatRegistration(typeof(GbVatRegistration)),
                "DE" => _FindVatRegistration(typeof(DeVatRegistration)),
                "FR" => _FindVatRegistration(typeof(FrVatRegistration)),
                _ => null
            };
        }

        private IVatRegistration<VatRegistrationModel>? _FindVatRegistration(Type type)
        {
            return _vatRegistrations.FirstOrDefault(x => x.GetType() == type);
        }
    }
}
