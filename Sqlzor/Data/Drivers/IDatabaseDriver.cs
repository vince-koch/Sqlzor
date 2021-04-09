using System.Data.Common;

namespace Sqlzor.Data.Drivers
{
    public interface IDatabaseDriver
    {
        string ProviderName { get; }

        DbConnectionStringBuilder CreateConnectionStringBuilder();

        DbConnection CreateConnection();
    }
}
