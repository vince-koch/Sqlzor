using System.Diagnostics;

namespace Sqlzor.DbSchema.Models
{
    [DebuggerDisplay("ProcedureParameter [{RoutineName}.{ParameterName}]")]
    public class ProcedureParameterModel
    {
        public string RoutineCatalog { get; set; }

        public string RoutineSchema { get; set; }

        public string RoutineName { get; set; }

        public string ParameterName { get; set; }

        public int OrdinalPosition { get; set; }

        public string ParameterMode { get; set; }

        public bool IsResult { get; set; }       

        public string DataType { get; set; }

        public long? CharacterMaximumLength { get; set; }
    }
}
