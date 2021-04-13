using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Drivers.Abstract
{
    public abstract class AbstractSchemaMapper : ISchemaMapper
    {
        public abstract SchemaModel MapSchema(Dictionary<string, DataTable> dataTables);

        protected virtual List<TItem> MapCollection<TItem>(Dictionary<string, DataTable> dataTables, string collectionName, Func<DataRow, TItem> mapRow)
        {
            var dataTable = dataTables[collectionName];
            if (dataTable == null)
            {
                return new List<TItem>();
            }

            try
            {
                var rows = dataTable.Rows.Cast<DataRow>();
                var list = rows.Select(item => mapRow(item)).ToList();
                return list;
            }
            catch (Exception)
            {
                Debug.WriteLine(dataTable.AsString());
                throw;
            }
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
