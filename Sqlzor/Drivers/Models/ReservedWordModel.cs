using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    /// <summary>
    /// This schema collection exposes information about the words that are reserved by the database that the.NET Framework managed provider that is currently connected to.
    /// </summary>
    [DebuggerDisplay("ReservedWord [{Word}]")]
    public class ReservedWordModel
    {
        /// <summary>
        /// Provider specific reserved word.
        /// </summary>
        public string Word { get; set; }
    }
}
