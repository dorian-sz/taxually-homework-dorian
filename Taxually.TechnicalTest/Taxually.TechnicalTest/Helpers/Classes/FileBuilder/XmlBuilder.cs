using System.Xml.Serialization;
using Taxually.TechnicalTest.Helpers.Interfaces.FileBuilder;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers.Classes.FileBuilder
{
    public class XmlBuilder : IXmlBuilder<VatRegistrationModel>
    {
        public string BuildXml(VatRegistrationModel registrationModel)
        {
            using var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(VatRegistrationModel));
            serializer.Serialize(stringWriter, registrationModel);
            var xml = stringWriter.ToString();
            return xml;
        }
    }
}
