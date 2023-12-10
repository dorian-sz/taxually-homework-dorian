using System.Text;

namespace Taxually.TechnicalTest.Helpers.Interfaces.FileBuilder
{
    public interface ICsvBuilder
    {
        byte[] BuildCsv(string companyName, string companyId);
    }
}
