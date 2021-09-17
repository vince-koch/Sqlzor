using System.Data;
using System.Linq;
using System.Text;

namespace Sqlzor.DbSchema
{
    public static partial class ExtensionMethods
    {
        public static string AsString(this DataTable dataTable, int maxRows = -1)
        {
            StringBuilder output = new StringBuilder();

            DataRow[] rows = maxRows > 0
                ? dataTable.Rows.OfType<DataRow>().Take(maxRows).ToArray()
                : dataTable.Rows.OfType<DataRow>().ToArray();

            // Get column widths
            int[] columnsWidths = new int[dataTable.Columns.Count];
            foreach (DataRow row in rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    int length = row[i].ToString().Length;
                    if (columnsWidths[i] < length)
                    {
                        columnsWidths[i] = length;
                    }
                }
            }

            // Get Column Titles
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                int length = dataTable.Columns[i].ColumnName.Length;
                if (columnsWidths[i] < length)
                {
                    columnsWidths[i] = length;
                }
            }

            // Write Column titles
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var text = dataTable.Columns[i].ColumnName;
                output.Append("|" + text.PadRight(columnsWidths[i] + 2));
            }

            output.Append("|\n" + new string('=', output.Length + 1) + "\n");

            // Write Rows
            foreach (DataRow row in rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    var text = row[i].ToString();
                    output.Append("|" + text.PadRight(columnsWidths[i] + 2));
                }

                output.Append("|\n");
            }

            return output.ToString();
        }

        private static string PadCenter(string text, int maxLength)
        {
            int diff = maxLength - text.Length;
            return new string(' ', diff / 2) + text + new string(' ', (int)((diff / 2.0) + 0.5));
        }
    }
}
