using System.Diagnostics;

namespace Sqlzor.DbSchema.Models
{
    [DebuggerDisplay("View [{ViewCatalog}.{ViewSchema}.{ViewName}]")]
    public class ViewModel
    {
        public string ViewCatalog { get; set; }

        public string ViewSchema { get; set; }

        public string ViewName { get; set; }
    }
}
