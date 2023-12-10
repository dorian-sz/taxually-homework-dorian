using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Interfaces.FileBuilder
{
    public interface IXmlBuilder<T>
    {
        string BuildXml(T registrationModel);
    }
}
