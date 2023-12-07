namespace Taxually.TechnicalTest.Helpers.Interfaces.VatRegistrationFactory
{
    public interface IVatRegistrationFactory<T>
    {
        T? GetRegistrationInstance(string countryCode);
    }
}
