using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Drivers.Abstract
{
    public abstract class AbstractSchemaMapper : ISchemaMapper
    {
        public virtual SchemaModel ConvertSchema(Dictionary<string, DataTable> dataTables)
        {
            var schema = new SchemaModel();
            schema.SourceDataTables = dataTables;

            schema.Columns = MapCollection(dataTables, "Columns", MapColumn);
            schema.Databases = MapCollection(dataTables, "Databases", MapDatabase);
            schema.DataSourceInformation = MapCollection(dataTables, "DataSourceInformation", MapDataSourceInformation);
            schema.DataTypes = MapCollection(dataTables, "DataType", MapDataType);
            schema.ForeignKeys = MapCollection(dataTables, "ForeignKeys", MapForeignKey);
            schema.Indexes = MapCollection(dataTables, "Indexes", MapIndex);
            schema.IndexColumns = MapCollection(dataTables, "IndexColumns", MapIndexColumn);
            schema.MetaDataCollections = MapCollection(dataTables, "MetaDataCollections", MapMetaDataCollection);
            schema.Procedures = MapCollection(dataTables, "Procedures", MapProcedure);
            schema.ProcedureParameters = MapCollection(dataTables, "ProcedureParameters", MapProcedureParameter);
            schema.ReservedWords = MapCollection(dataTables, "ReservedWords", MapReservedWord);
            schema.Restrictions = MapCollection(dataTables, "Restrictions", MapRestriction);
            schema.Tables = MapCollection(dataTables, "Tables", MapTable);
            schema.Users = MapCollection(dataTables, "Users", MapUser);
            schema.Views = MapCollection(dataTables, "Views", MapView);
            schema.ViewColumns = MapCollection(dataTables, "ViewColumns", MapViewColumn);

            return schema;
        }

        protected virtual List<TItem> MapCollection<TItem>(Dictionary<string, DataTable> dataTables, string collectionName, Func<DataRow, TItem> mapRow)
        {
            var dataTable = dataTables[collectionName];
            var rows = dataTable.Rows.Cast<DataRow>();
            var list = rows.Select(item => mapRow(item)).ToList();
            return list;
        }

        protected abstract Column MapColumn(DataRow row);

        protected abstract Database MapDatabase(DataRow row);

        protected abstract DataSourceInformation MapDataSourceInformation(DataRow row);

        protected abstract DataType MapDataType(DataRow row);

        protected abstract ForeignKey MapForeignKey(DataRow row);

        protected abstract Models.Index MapIndex(DataRow row);

        protected abstract IndexColumn MapIndexColumn(DataRow row);

        protected abstract MetaDataCollection MapMetaDataCollection(DataRow row);

        protected abstract Procedure MapProcedure(DataRow row);

        protected abstract ProcedureParameter MapProcedureParameter(DataRow row);

        protected abstract ReservedWord MapReservedWord(DataRow row);

        protected abstract Restriction MapRestriction(DataRow row);

        protected abstract Table MapTable(DataRow row);

        protected abstract User MapUser(DataRow row);

        protected abstract View MapView(DataRow row);

        protected abstract ViewColumn MapViewColumn(DataRow row);
    }
}
