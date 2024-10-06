using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Models;

using System.Data;

namespace Sqlzor.DbSchema.Mongo
{
    public class MongoSchemaMapper : AbstractSchemaMapper
    {
        public override SchemaModel MapSchema(DataTable[] dataTables)
        {
            throw new NotImplementedException();
        }

        protected override ColumnModel MapColumn(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override DatabaseModel MapDatabase(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override DataSourceInformationModel MapDataSourceInformation(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override DataTypeModel MapDataType(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override ForeignKeyModel MapForeignKey(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override IndexModel MapIndex(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override IndexColumnModel MapIndexColumn(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override MetaDataCollectionModel MapMetaDataCollection(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override ProcedureModel MapProcedure(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override ProcedureParameterModel MapProcedureParameter(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override ReservedWordModel MapReservedWord(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override RestrictionModel MapRestriction(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override TableModel MapTable(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override UserModel MapUser(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override ViewModel MapView(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override ViewColumnModel MapViewColumn(DataRow row)
        {
            throw new NotImplementedException();
        }
    }
}
