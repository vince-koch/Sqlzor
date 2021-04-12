using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("Databases")]
    [DebuggerDisplay("Database [{DatabaseName}]")]
    public class Database
    {
        [SchemaColumn("DATABASE_NAME")]
        public string DatabaseName { get; set; }
    }
}
