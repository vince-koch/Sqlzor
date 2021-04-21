using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("View [{ViewCatalog}.{ViewSchema}.{ViewName}]")]
    public class ViewModel
    {
        public string ViewCatalog { get; set; }

        public string ViewSchema { get; set; }

        public string ViewName { get; set; }
    }
}
