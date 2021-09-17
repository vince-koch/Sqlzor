using System.Diagnostics;

namespace Sqlzor.DbSchema.Models
{
    [DebuggerDisplay("Database [{DatabaseName}]")]
    public class DatabaseModel
    {
        public string DatabaseName { get; set; }
    }
}
