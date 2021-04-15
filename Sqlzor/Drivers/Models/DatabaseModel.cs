using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("Database [{DatabaseName}]")]
    public class DatabaseModel
    {
        public string DatabaseName { get; set; }
    }
}
