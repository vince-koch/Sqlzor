using System.Collections.Generic;
using System.Data;

namespace Sqlzor.Data.Drivers.Models
{
    public class SchemaModel
    {
        public string ProviderName { get; set; }

        public Dictionary<string, DataTable> SourceDataTables { get; set; }

        public List<Column> Columns { get; set; }

        public List<Database> Databases { get; set; }

        public List<DataSourceInformation> DataSourceInformation { get; set; }

        public List<DataType> DataTypes { get; set; }

        public List<ForeignKey> ForeignKeys { get; set; }

        public List<Index> Indexes { get; set; }

        public List<IndexColumn> IndexColumns { get; set; }

        public List<MetaDataCollection> MetaDataCollections { get; set; }

        public List<Procedure> Procedures { get; set; }

        public List<ProcedureParameter> ProcedureParameters { get; set; }

        public List<ReservedWord> ReservedWords { get; set; }

        public List<Table> Tables { get; set; }

        public List<User> Users { get; set; }

        public List<View> View { get; set; }

        public List<ViewColumn> ViewColumns { get; set; }
    }
}
