using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    /// <summary>
    /// This schema collection exposes information about the words that are reserved by the database that the.NET Framework managed provider that is currently connected to.
    /// </summary>
    [SchemaTable("ReservedWords")]
    [DebuggerDisplay("ReservedWord [{Word}]")]
    public class ReservedWord
    {
        /// <summary>
        /// Provider specific reserved word.
        /// </summary>
        [SchemaColumn("ReservedWord")]
        public string Word { get; set; }
    }
}
