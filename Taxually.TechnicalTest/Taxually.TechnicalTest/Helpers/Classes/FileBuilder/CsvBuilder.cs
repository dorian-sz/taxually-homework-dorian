using System.Text;
using Taxually.TechnicalTest.Helpers.Interfaces.FileBuilder;

namespace Taxually.TechnicalTest.Helpers.Classes.FileBuilder
{
    public class CsvBuilder : ICsvBuilder
    {
        public byte[] BuildCsv(string companyName, string companyId)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{companyName},{companyId}");

            return Encoding.UTF8.GetBytes(csvBuilder.ToString());
        }
    }
}
