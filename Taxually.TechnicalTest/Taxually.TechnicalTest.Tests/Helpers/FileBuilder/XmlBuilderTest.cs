using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Taxually.TechnicalTest.Helpers.Classes.FileBuilder;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Tests.Helpers.FileBuilder
{
    public class XmlBuilderTest
    {
        [Fact]
        public void BuildXml_String_IsValidXml_True()
        {
            //Arrange
            var xmlBuilder = new XmlBuilder();
            var registrationModel = new VatRegistrationModel();
            var xmlString = xmlBuilder.BuildXml(registrationModel);
            var expected = true;
            //Act
            var actual = IsValidXml(xmlString);

            //Assert
            Assert.Equal(expected, actual);

        }
        private bool IsValidXml(string xmlString)
        {
            try
            {
                // Attempt to parse the string as XML
                XDocument.Parse(xmlString);
                return true;
            }
            catch (System.Xml.XmlException)
            {
                // Parsing failed, so it's not a valid XML
                return false;
            }
        }
    }
}
