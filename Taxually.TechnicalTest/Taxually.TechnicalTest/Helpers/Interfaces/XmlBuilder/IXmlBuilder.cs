using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Interfaces.XmlBuilder
{
    public interface IXmlBuilder<T>
    {
        string BuildXml(T registrationModel);
    }
}
