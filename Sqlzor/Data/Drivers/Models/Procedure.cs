using System;
using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("Procedures")]
    [DebuggerDisplay("Procedure [{RoutineCatalog}.{RoutineSchema}.{RoutineName}]")]
    public class Procedure
    {
        [SchemaColumn("SPECIFIC_CATALOG")]
        public string SpecificCatalog { get; set; }

        [SchemaColumn("SPECIFIC_SCHEMA")]
        public string SpecificSchema { get; set; }

        [SchemaColumn("SPECIFIC_NAME")]
        public string SpecificName { get; set; }

        [SchemaColumn("ROUTINE_CATALOG")]
        public string RoutineCatalog { get; set; }

        [SchemaColumn("ROUTINE_SCHEMA")]
        public string RoutineSchema { get; set; }

        [SchemaColumn("ROUTINE_NAME")]
        public string RoutineName { get; set; }

        [SchemaColumn("ROUTINE_TYPE")]
        public string RoutineType { get; set; }

        [SchemaColumn("CREATED")]
        public DateTime Created { get; set; }

        [SchemaColumn("LAST_ALTERED")]
        public DateTime LastAltered { get; set; }
    }
}
