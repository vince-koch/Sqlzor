using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    /// <summary>
    /// This schema collection exposes information about all of the schema collections supported by the .NET Framework managed provider that is currently used to connect to the database.
    /// </summary>
    [DebuggerDisplay("MetaDataCollection [{CollectionName}]")]
    public class MetaDataCollection
    {
        /// <summary>
        /// The name of the collection to pass to the GetSchema method to return the collection.
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// The number of restrictions that may be specified for the collection.
        /// </summary>
        public int NumberOfRestrictions { get; set; }

        /// <summary>
        /// The number of parts in the composite identifier/database object name. For example, in SQL Server, this would be 3 for tables and 4 for columns. In Oracle, it would be 2 for tables and 3 for columns.
        /// </summary>
        public int NumberOfIdentifierParts { get; set; }
    }
}
