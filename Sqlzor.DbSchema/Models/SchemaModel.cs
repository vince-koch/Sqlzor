using System.Collections.Generic;
using System.Data;

namespace Sqlzor.DbSchema.Models
{
    public class SchemaModel
    {
        public string ProviderName { get; set; }

        public DataTable[] SourceDataTables { get; set; }

        public List<ColumnModel> Columns { get; set; }

        public List<DatabaseModel> Databases { get; set; }

        public List<DataSourceInformationModel> DataSourceInformation { get; set; }

        public List<DataTypeModel> DataTypes { get; set; }

        public List<ForeignKeyModel> ForeignKeys { get; set; }

        public List<IndexModel> Indexes { get; set; }

        public List<IndexColumnModel> IndexColumns { get; set; }

        public List<MetaDataCollectionModel> MetaDataCollections { get; set; }

        public List<ProcedureModel> Procedures { get; set; }

        public List<ProcedureParameterModel> ProcedureParameters { get; set; }

        public List<ReservedWordModel> ReservedWords { get; set; }

        public List<RestrictionModel> Restrictions { get; set; }

        public List<TableModel> Tables { get; set; }

        public List<UserModel> Users { get; set; }

        public List<ViewModel> Views { get; set; }

        public List<ViewColumnModel> ViewColumns { get; set; }
    }
}
