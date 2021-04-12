using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("Restrictions")]
    [DebuggerDisplay("Restriction [{CollectionName}.{RestrictionName}]")]
    public class Restriction
    {
        /// <summary>
        /// string The name of the collection that these restrictions apply to.
        /// </summary>
        [SchemaColumn("CollectionName")]
        public string CollectionName { get; set; }

        /// <summary>
        /// RestrictionName string The name of the restriction in the collection.
        /// </summary>
        [SchemaColumn("RestrictionName")]
        public string RestrictionName { get; set; }

        /// <summary>
        /// The actual location in the collections restrictions that this particular restriction falls in.
        /// </summary>
        [SchemaColumn("RestrictionNumber")]
        public int RestrictionNumber { get; set; }
    }
}
