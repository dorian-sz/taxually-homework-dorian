using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Helpers.Classes.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.Client;
using Taxually.TechnicalTest.Helpers.Interfaces.FileBuilder;
using Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Tests.Helpers.VatRegistration
{
    public class DeVatRegistrationTest
    {
        [Fact]
        public async void Register_ObjectValid_ReturnsTrue()
        {
        //Arrange
            var registrationModel = new Mock<VatRegistrationModel>();
            var propertyChecker = new Mock<IModelPropertyChecker<VatRegistrationModel>>();
            var xmlBuilder = new Mock<IXmlBuilder<VatRegistrationModel>>();
            var queueClient = new Mock<ITaxuallyQueueClient<string>>();
            propertyChecker.Setup(_ => _.AnyPropertiesDefault(registrationModel.Object)).Returns(false);

            var vatRegistration = new DeVatRegistration(queueClient.Object, xmlBuilder.Object, propertyChecker.Object);
            bool expected = true;

            //Act
            var actual = await vatRegistration.Register(registrationModel.Object);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void Register_ObjectNotValid_ReturnsFalse()
        {
            //Arrange
            var registrationModel = new Mock<VatRegistrationModel>();
            var propertyChecker = new Mock<IModelPropertyChecker<VatRegistrationModel>>();
            var xmlBuilder = new Mock<IXmlBuilder<VatRegistrationModel>>();
            var queueClient = new Mock<ITaxuallyQueueClient<string>>();
            propertyChecker.Setup(_ => _.AnyPropertiesDefault(registrationModel.Object)).Returns(true);

            var vatRegistration = new DeVatRegistration(queueClient.Object, xmlBuilder.Object, propertyChecker.Object);
            bool expected = false;

            //Act
            var actual = await vatRegistration.Register(registrationModel.Object);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
