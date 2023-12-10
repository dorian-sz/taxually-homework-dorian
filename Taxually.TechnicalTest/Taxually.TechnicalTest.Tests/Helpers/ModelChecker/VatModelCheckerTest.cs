using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxually.TechnicalTest.Helpers.Classes.ModelChecker;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Tests.Helpers.ModelChecker
{
    public class VatModelCheckerTest
    {
        private readonly VatModelChecker _vatModelChecker;

        public VatModelCheckerTest()
        {
            _vatModelChecker = new VatModelChecker();
        }

        [Fact]
        public void AnyPropertiesDefault_ObjectNonEmptyValues_ReturnsTrue()
        {
            //Arrange
            var registrationModel = new VatRegistrationModel() { 
                CompanyName = "Test",
                CompanyId = "1",
                Country = "Gb"
            };
            bool expected = false;

            //Act
            var actual = _vatModelChecker.AnyPropertiesDefault(registrationModel);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AnyPropertiesDefault_ObjectEmptyValue_ReturnsFalse()
        {
            //Arrange
            var registrationModel = new VatRegistrationModel()
            {
                CompanyName = "Test",
                CompanyId = "",
                Country = ""
            };
            bool expected = true;

            //Act
            var actual = _vatModelChecker.AnyPropertiesDefault(registrationModel);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
