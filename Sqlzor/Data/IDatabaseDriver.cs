using System.Data.Common;

namespace Sqlzor.Data
{
    public interface IDatabaseDriver
    {
        string ProviderName { get; }

        DbConnectionStringBuilder CreateConnectionStringBuilder();

        DbConnection CreateConnection();
    }
}
