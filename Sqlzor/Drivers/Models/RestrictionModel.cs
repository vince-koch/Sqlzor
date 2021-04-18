using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("Restriction [{CollectionName}.{RestrictionName}]")]
    public class RestrictionModel
    {
        /// <summary>
        /// string The name of the collection that these restrictions apply to.
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// RestrictionName string The name of the restriction in the collection.
        /// </summary>
        public string RestrictionName { get; set; }

        /// <summary>
        /// The actual location in the collections restrictions that this particular restriction falls in.
        /// </summary>
        public int RestrictionNumber { get; set; }
    }
}
