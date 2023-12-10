using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Helpers.Classes.ModelChecker;
using Taxually.TechnicalTest.Helpers.Classes.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.Client;
using Taxually.TechnicalTest.Helpers.Interfaces.FileBuilder;
using Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Tests.Helpers.VatRegistration
{
    public class FrVatRegistrationTest
    {
        [Fact]
        public async void Register_ObjectValid_ReturnsTrue()
        {
            //Arrange
            var registrationModel = new Mock<VatRegistrationModel>();
            var propertyChecker = new Mock<IModelPropertyChecker<VatRegistrationModel>>();
            var csvBuilder = new Mock<ICsvBuilder>();
            var queueClient = new Mock<ITaxuallyQueueClient<byte[]>>();
            propertyChecker.Setup(_ => _.AnyPropertiesDefault(registrationModel.Object)).Returns(false);

            var vatRegistration = new FrVatRegistration(queueClient.Object, csvBuilder.Object, propertyChecker.Object);
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
            var csvBuilder = new Mock<ICsvBuilder>();
            var queueClient = new Mock<ITaxuallyQueueClient<byte[]>>();
            propertyChecker.Setup(_ => _.AnyPropertiesDefault(registrationModel.Object)).Returns(true);

            var vatRegistration = new FrVatRegistration(queueClient.Object, csvBuilder.Object, propertyChecker.Object);
            bool expected = false;

            //Act
            var actual = await vatRegistration.Register(registrationModel.Object);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
