using System.Text;

namespace Taxually.TechnicalTest.Helpers.Interfaces.CsvBuilder
{
    public interface ICsvBuilder
    {
        byte[] BuildCsv(string companyName, string companyId);
    }
}
