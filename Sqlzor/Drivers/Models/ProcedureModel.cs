using System;
using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("Procedure [{RoutineCatalog}.{RoutineSchema}.{RoutineName}]")]
    public class ProcedureModel
    {
        public string RoutineCatalog { get; set; }

        public string RoutineSchema { get; set; }

        public string RoutineName { get; set; }

        public string RoutineType { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastAltered { get; set; }
    }
}
