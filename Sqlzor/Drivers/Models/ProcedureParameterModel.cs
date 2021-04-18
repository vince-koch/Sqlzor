using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("ProcedureParameter [{SpecificName}.{ParameterName}]")]
    public class ProcedureParameterModel
    {
        public string SpecificCatalog { get; set; }

        public string SpecificSchema { get; set; }

        public string SpecificName { get; set; }

        public int OrdinalPosition { get; set; }

        public string ParameterMode { get; set; }

        public bool IsResult { get; set; }

        public string ParameterName { get; set; }

        public string DataType { get; set; }

        public string CharacterMaximumLength { get; set; }
    }
}
