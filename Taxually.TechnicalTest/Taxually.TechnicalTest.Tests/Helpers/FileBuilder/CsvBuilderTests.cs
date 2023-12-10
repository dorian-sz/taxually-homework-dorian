using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Helpers.Classes.FileBuilder;

namespace Taxually.TechnicalTest.Tests.Helpers.FileBuilder
{
    public class CsvBuilderTests
    {
        private readonly CsvBuilder _builder;
        
        public CsvBuilderTests()
        {
            _builder = new CsvBuilder();
        }

        [Fact]
        public void BuildCsv_StringArguments_HasCorrectReturnType()
        {
            //Arrange
            var expected = typeof(byte[]);

            //Act
            var actual = _builder.BuildCsv("", "");

            //Assert
            Assert.IsType(expected, actual);
        }

        [Fact]
        public void BuildCsv_StringArguments_HasCorrectHeaders()
        {
            //Arrange
            var expectedHeaders = "CompanyName,CompanyId";
            bool expected = true;

            //Act
            var result = _builder.BuildCsv("a", "1");
            var resultString = Encoding.UTF8.GetString(result);
            var resultHeader = resultString.Split('\n', StringSplitOptions.RemoveEmptyEntries)[0];
            var actual = resultHeader.Contains(expectedHeaders);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BuildCsv_StringArguments_HasCorrectBody()
        {
            //Arrange
            var expectedHeaders = "Company a,1";
            bool expected = true;

            //Act
            var result = _builder.BuildCsv("Company a", "1");
            var resultString = Encoding.UTF8.GetString(result);
            var resultHeader = resultString.Split('\n', StringSplitOptions.RemoveEmptyEntries)[1];
            var actual = resultHeader.Contains(expectedHeaders);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
