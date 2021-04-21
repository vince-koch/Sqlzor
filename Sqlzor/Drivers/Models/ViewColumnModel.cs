using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("ViewColumn [{ViewName}.{ViewColumn}]")]
    public class ViewColumnModel
    {
        public string ViewCatalog { get; set; }

        public string ViewSchema { get; set; }

        public string ViewName { get; set; }

        public string ColumnName { get; set; }

        public int OrdinalPosition { get; set; }

        public bool IsNullable { get; set; }

        public string DataType { get; set; }

        public long? CharacterMaximumLength { get; set; }
    }
}
