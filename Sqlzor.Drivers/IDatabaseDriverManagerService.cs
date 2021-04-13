using System.Data.Common;

namespace Sqlzor.Drivers
{
    public interface IDatabaseDriverManagerService
    {
        IDatabaseDriver GetDriver(string providerName);

        IDatabaseDriver GetDriver(DbConnection connection);
    }
}
