using System;
using System.Collections.Generic;
using System.Data;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Models;

namespace Sqlzor.DbSchema.SqlLite
{
    public class SQLiteSchemaMapper : AbstractSchemaMapper
    {
        public override SchemaModel MapSchema(DataTable[] dataTables)
        {
            var schema = new SchemaModel();
            schema.SourceDataTables = dataTables;

            schema.Columns = MapCollection(dataTables, "Columns", MapColumn);
            schema.Databases = MapCollection(dataTables, "Catalogs", MapDatabase);
            schema.DataSourceInformation = MapCollection(dataTables, "DataSourceInformation", MapDataSourceInformation);
            schema.DataTypes = MapCollection(dataTables, "DataTypes", MapDataType);
            schema.ForeignKeys = MapCollection(dataTables, "ForeignKeys", MapForeignKey);
            schema.Indexes = MapCollection(dataTables, "Indexes", MapIndex);
            schema.IndexColumns = MapCollection(dataTables, "IndexColumns", MapIndexColumn);
            schema.MetaDataCollections = MapCollection(dataTables, "MetaDataCollections", MapMetaDataCollection);
            schema.Procedures = new List<ProcedureModel>();
            schema.ProcedureParameters = new List<ProcedureParameterModel>();
            schema.ReservedWords = MapCollection(dataTables, "ReservedWords", MapReservedWord);
            schema.Restrictions = new List<RestrictionModel>();
            schema.Tables = MapCollection(dataTables, "Tables", MapTable);
            schema.Users = new List<UserModel>();
            schema.Views = MapCollection(dataTables, "Views", MapView);
            schema.ViewColumns = MapCollection(dataTables, "ViewColumns", MapViewColumn);

            return schema;
        }

        protected override ColumnModel MapColumn(DataRow row)
        {
            var column = new ColumnModel();
            column.TableCatalog = row.GetString("TABLE_CATALOG");
            column.TableName = row.GetString("TABLE_NAME");
            column.ColumnName = row.GetString("COLUMN_NAME");
            column.OrdinalPosition = row.GetInt("ORDINAL_POSITION");
            column.ColumnDefault = row.GetString("COLUMN_DEFAULT");
            column.IsNullable = row.GetBool("IS_NULLABLE");
            column.DataType = row.GetString("DATA_TYPE");
            column.CharacterMaximumLength = row.GetNullableLong("CHARACTER_MAXIMUM_LENGTH");

            return column;
        }

        protected override DatabaseModel MapDatabase(DataRow row)
        {
            var database = new DatabaseModel();
            database.DatabaseName = row.GetString("CATALOG_NAME");

            return database;
        }

        protected override DataSourceInformationModel MapDataSourceInformation(DataRow row)
        {
            var dataSourceInformation = new DataSourceInformationModel();
            dataSourceInformation.CompositeIdentifierSeparatorPattern = row.GetString("CompositeIdentifierSeparatorPattern");
            dataSourceInformation.DataSourceProductName = row.GetString("DataSourceProductName");
            dataSourceInformation.DataSourceProductVersion = row.GetString("DataSourceProductVersion");
            dataSourceInformation.DataSourceProductVersionNormalized = row.GetString("DataSourceProductVersionNormalized");
            dataSourceInformation.GroupByBehavior = row.GetInt("GroupByBehavior");
            dataSourceInformation.IdentifierPattern = row.GetString("IdentifierPattern");
            dataSourceInformation.IdentifierCase = row.GetInt("IdentifierCase");
            dataSourceInformation.OrderByColumnsInSelect = row.GetBool("OrderByColumnsInSelect");
            dataSourceInformation.ParameterMarkerFormat = row.GetString("ParameterMarkerFormat");
            dataSourceInformation.ParameterNameMaxLength = row.GetInt("ParameterNameMaxLength");
            dataSourceInformation.ParameterNamePattern = row.GetString("ParameterNamePattern");
            dataSourceInformation.QuotedIdentifierPattern = row.GetString("QuotedIdentifierPattern");
            dataSourceInformation.QuotedIdentifierCase = row.GetInt("QuotedIdentifierCase");
            dataSourceInformation.StatementSeparatorPattern = row.GetString("StatementSeparatorPattern");
            dataSourceInformation.StringLiteralPattern = row.GetString("StringLiteralPattern");
            dataSourceInformation.SupportedJoinOperators = row.GetInt("SupportedJoinOperators");

            return dataSourceInformation;
        }

        protected override DataTypeModel MapDataType(DataRow row)
        {
            var dataType = new DataTypeModel();
            dataType.TypeName = row.GetString("TypeName");
            dataType.ProviderDbType = row.GetNullableInt("ProviderDbType");
            dataType.ColumnSize = row.GetNullableLong("ColumnSize");
            dataType.CreateFormat = row.GetString("CreateFormat");
            dataType.CreateParameters = row.GetString("CreateParameters");
            dataType.DataTypeName = row.GetString("DataType");
            dataType.IsAutoincrementable = row.GetNullableBool("IsAutoincrementable");
            dataType.IsBestMatch = row.GetNullableBool("IsBestMatch");
            dataType.IsCaseSensitive = row.GetNullableBool("IsCaseSensitive");
            dataType.IsFixedLength = row.GetNullableBool("IsFixedLength");
            dataType.IsFixedPrecisionScale = row.GetNullableBool("IsFixedPrecisionScale");
            dataType.IsLong = row.GetNullableBool("IsLong");
            dataType.IsNullable = row.GetNullableBool("IsNullable");
            dataType.IsSearchable = row.GetNullableBool("IsSearchable");
            dataType.IsSearchableWithLike = row.GetNullableBool("IsSearchableWithLike");
            dataType.IsUnsigned = row.GetNullableBool("IsUnsigned");
            dataType.MaximumScale = row.GetNullableShort("MaximumScale");
            dataType.MinimumScale = row.GetNullableShort("MinimumScale");
            dataType.IsConcurrencyType = row.GetNullableBool("IsConcurrencyType");
            dataType.IsLiteralSupported = row.GetNullableBool("IsLiteralSupported");
            dataType.LiteralPrefix = row.GetString("LiteralPrefix");
            dataType.LiteralSuffix = row.GetString("LiteralSuffix");

            return dataType;
        }

        protected override ForeignKeyModel MapForeignKey(DataRow row)
        {
            var foreignKey = new ForeignKeyModel();
            foreignKey.TableCatalog = row.GetString("TABLE_CATALOG");
            foreignKey.TableSchema = row.GetString("TABLE_SCHEMA");
            foreignKey.TableName = row.GetString("TABLE_NAME");
            foreignKey.ConstraintName = row.GetString("CONSTRAINT_NAME");
            foreignKey.ReferencedTableCatalog = row.GetString("FKEY_TO_CATALOG");
            foreignKey.ReferencedTableSchema = row.GetString("FKEY_TO_SCHEMA");
            foreignKey.ReferencedTableName = row.GetString("FKEY_TO_TABLE");
            foreignKey.ReferencedColumnName = row.GetString("FKEY_TO_COLUMN");

            return foreignKey;
        }

        protected override IndexModel MapIndex(DataRow row)
        {
            var index = new IndexModel();
            index.TableCatalog = row.GetString("TABLE_CATALOG");
            index.TableSchema = row.GetString("TABLE_SCHEMA");
            index.TableName = row.GetString("TABLE_NAME");
            index.IndexName = row.GetString("INDEX_NAME");
            index.IsPrimary = row.GetBool("PRIMARY_KEY");
            index.IsUnique = row.GetBool("UNIQUE");
            index.IsClustered = row.GetNullableBool("CLUSTERED");

            return index;
        }

        protected override IndexColumnModel MapIndexColumn(DataRow row)
        {
            var indexColumn = new IndexColumnModel();
            indexColumn.TableCatalog = row.GetString("TABLE_CATALOG");
            indexColumn.TableSchema = row.GetString("TABLE_SCHEMA");
            indexColumn.TableName = row.GetString("TABLE_NAME");
            indexColumn.IndexName = row.GetString("INDEX_NAME");
            indexColumn.ColumnName = row.GetString("COLUMN_NAME");
            indexColumn.OrdinalPostion = row.GetInt("ORDINAL_POSITION");

            return indexColumn;
        }

        protected override MetaDataCollectionModel MapMetaDataCollection(DataRow row)
        {
            var collection = new MetaDataCollectionModel();
            collection.CollectionName = row.GetString("CollectionName");
            collection.NumberOfRestrictions = row.GetInt("NumberOfRestrictions");
            collection.NumberOfIdentifierParts = row.GetNullableInt("NumberOfIdentifierParts");

            return collection;
        }

        protected override ProcedureModel MapProcedure(DataRow row)
        {
            throw new NotSupportedException();
        }

        protected override ProcedureParameterModel MapProcedureParameter(DataRow row)
        {
            throw new NotSupportedException();
        }

        protected override ReservedWordModel MapReservedWord(DataRow row)
        {
            var reservedWord = new ReservedWordModel();
            reservedWord.Word = row.GetString("ReservedWord");

            return reservedWord;
        }

        protected override RestrictionModel MapRestriction(DataRow row)
        {
            var restriction = new RestrictionModel();
            restriction.CollectionName = row.GetString("CollectionName");
            restriction.RestrictionName = row.GetString("RestrictionName");
            restriction.RestrictionNumber = row.GetInt("RestrictionNumber");

            return restriction;
        }

        protected override TableModel MapTable(DataRow row)
        {
            var table = new TableModel();
            table.TableCatalog = row.GetString("TABLE_CATALOG");
            table.TableSchema = row.GetString("TABLE_SCHEMA");
            table.TableName = row.GetString("TABLE_NAME");
            table.TableType = row.GetString("TABLE_TYPE");

            return table;
        }

        protected override UserModel MapUser(DataRow row)
        {
            throw new NotSupportedException();
        }

        protected override ViewModel MapView(DataRow row)
        {
            var view = new ViewModel();
            view.ViewCatalog = row.GetString("TABLE_CATALOG");
            view.ViewSchema = row.GetString("TABLE_SCHEMA");
            view.ViewName = row.GetString("TABLE_NAME");

            return view;
        }

        protected override ViewColumnModel MapViewColumn(DataRow row)
        {
            var viewColumn = new ViewColumnModel();
            viewColumn.ViewCatalog = row.GetString("VIEW_CATALOG");
            viewColumn.ViewSchema = row.GetString("VIEW_SCHEMA");
            viewColumn.ViewName = row.GetString("VIEW_NAME");
            viewColumn.ColumnName = row.GetString("COLUMN_NAME");

            viewColumn.OrdinalPosition = row.GetInt("ORDINAL_POSITION");
            viewColumn.IsNullable = row.GetValue("IS_NULLABLE", CommonConverter.ConvertStringToBool);
            viewColumn.DataType = row.GetString("DATA_TYPE");
            viewColumn.CharacterMaximumLength = row.GetNullableLong("CHARACTER_MAXIMUM_LENGTH");

            return viewColumn;
        }
    }
}
