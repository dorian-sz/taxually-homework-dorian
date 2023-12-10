using Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.ModelChecker
{
    public class VatModelChecker : IModelPropertyChecker<VatRegistrationModel>
    {
        public bool AnyPropertiesDefault(VatRegistrationModel model)
        {
            return model.GetType().GetProperties()
                     .Where(pi => pi.PropertyType == typeof(string))
                     .Select(pi => pi.GetValue(model) as string)
                     .Any(value => string.IsNullOrEmpty(value));
        }
    }
}
