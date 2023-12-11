using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Controllers;
using Taxually.TechnicalTest.Helpers.Classes.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.Client;
using Taxually.TechnicalTest.Helpers.Interfaces.FileBuilder;
using Taxually.TechnicalTest.Helpers.Interfaces.ModelPropertyChecker;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistrationFactory;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Tests.Controllers
{
    public class VatRegistrationControllerTest
    {
        [Fact]
        public async void Post_ObjectModelValid_ReturnsOk()
        {
            //Arrange
            var registrationModel = new Mock<VatRegistrationModel>().Object;
            var registrationMethod = new Mock<IVatRegistration<VatRegistrationModel>>();
            var factory = new Mock<IVatRegistrationFactory<IVatRegistration<VatRegistrationModel>>>();

            factory.Setup(_ => _.GetRegistrationInstance(It.IsAny<string>())).Returns(registrationMethod.Object);
            registrationMethod.Setup(_ => _.Register(registrationModel)).Returns(Task.FromResult(true));
            var registrationController = new VatRegistrationController(factory.Object);
          
            //Act
            var actual = await registrationController.Post(registrationModel);

            //Assert
            Assert.IsType<OkResult>(actual);
        }

        [Fact]
        public async void Post_CountryNotValid_ReturnsBadRequest()
        {
            //Arrange
            var registrationModel = new Mock<VatRegistrationModel>().Object;
            var registrationMethod = new Mock<IVatRegistration<VatRegistrationModel>>();
            var factory = new Mock<IVatRegistrationFactory<IVatRegistration<VatRegistrationModel>>>();

            factory.Setup(_ => _.GetRegistrationInstance(It.IsAny<string>())).Returns<IVatRegistration<VatRegistrationModel>>(null);
            registrationMethod.Setup(_ => _.Register(registrationModel)).Returns(Task.FromResult(true));
            var registrationController = new VatRegistrationController(factory.Object);

            //Act
            var actual = await registrationController.Post(registrationModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actual);
        }

        [Fact]
        public async void Post_ObjectMissingValues_ReturnsBadRequest()
        {
            //Arrange
            var registrationModel = new Mock<VatRegistrationModel>().Object;
            var registrationMethod = new Mock<IVatRegistration<VatRegistrationModel>>();
            var factory = new Mock<IVatRegistrationFactory<IVatRegistration<VatRegistrationModel>>>();

            factory.Setup(_ => _.GetRegistrationInstance(It.IsAny<string>())).Returns(registrationMethod.Object);
            registrationMethod.Setup(_ => _.Register(registrationModel)).Returns(Task.FromResult(false));
            var registrationController = new VatRegistrationController(factory.Object);

            //Act
            var actual = await registrationController.Post(registrationModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actual);
        }
    }
}
