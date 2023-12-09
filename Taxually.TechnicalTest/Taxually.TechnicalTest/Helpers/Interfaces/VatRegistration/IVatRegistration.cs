using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration
{
    public interface IVatRegistration<T>
    {
        Task<bool> Register(T registrationModel);
    }
}
