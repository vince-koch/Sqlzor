using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("ProcedureParameters")]
    [DebuggerDisplay("ProcedureParameter [{SpecificName}.{ParameterName}]")]
    public class ProcedureParameter
    {
        [SchemaColumn("SPECIFIC_CATALOG")]
        public string SpecificCatalog { get; set; }

        [SchemaColumn("SPECIFIC_SCHEMA")]
        public string SpecificSchema { get; set; }

        [SchemaColumn("SPECIFIC_NAME")]
        public string SpecificName { get; set; }

        [SchemaColumn("ORDINAL_POSITION")]
        public int OrdinalPosition { get; set; }

        [SchemaColumn("PARAMETER_MODE")]
        public string ParameterMode { get; set; }

        [SchemaColumn("IS_RESULT")]
        public bool IsResult { get; set; }

        [SchemaColumn("PARAMETER_NAME")]
        public string ParameterName { get; set; }

        [SchemaColumn("DATA_TYPE")]
        public string DataType { get; set; }

        [SchemaColumn("CHARACTER_MAXIMUM_LENGTH ")]
        public string CharacterMaximumLength { get; set; }
    }
}
