using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("Database [{DatabaseName}]")]
    public class Database
    {
        public string DatabaseName { get; set; }
    }
}
