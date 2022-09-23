using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

using Sqlzor.DbSchema.Models;

namespace Sqlzor.DbSchema.Drivers
{
    public abstract class AbstractSchemaMapper : ISchemaMapper
    {
        public abstract SchemaModel MapSchema(DataTable[] dataTables);

        protected virtual List<TItem> MapCollection<TItem>(DataTable[] dataTables, string collectionName, Func<DataRow, TItem> mapRow)
        {
            var dataTable = dataTables.SingleOrDefault(item => item.TableName == collectionName);
            if (dataTable == null)
            {
                return new List<TItem>();
            }

            ////Debug.WriteLine(collectionName);
            ////Debug.WriteLine(dataTable.AsString(25));

            var rows = dataTable.Rows.Cast<DataRow>();
            var list = rows.Select(item => mapRow(item)).ToList();
            return list;
        }

        protected abstract ColumnModel MapColumn(DataRow row);

        protected abstract DatabaseModel MapDatabase(DataRow row);

        protected abstract DataSourceInformationModel MapDataSourceInformation(DataRow row);

        protected abstract DataTypeModel MapDataType(DataRow row);

        protected abstract ForeignKeyModel MapForeignKey(DataRow row);

        protected abstract Models.IndexModel MapIndex(DataRow row);

        protected abstract IndexColumnModel MapIndexColumn(DataRow row);

        protected abstract MetaDataCollectionModel MapMetaDataCollection(DataRow row);

        protected abstract ProcedureModel MapProcedure(DataRow row);

        protected abstract ProcedureParameterModel MapProcedureParameter(DataRow row);

        protected abstract ReservedWordModel MapReservedWord(DataRow row);

        protected abstract RestrictionModel MapRestriction(DataRow row);

        protected abstract TableModel MapTable(DataRow row);

        protected abstract UserModel MapUser(DataRow row);

        protected abstract ViewModel MapView(DataRow row);

        protected abstract ViewColumnModel MapViewColumn(DataRow row);
    }
}
