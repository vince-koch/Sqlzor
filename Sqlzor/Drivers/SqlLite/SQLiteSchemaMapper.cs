using System;
using System.Collections.Generic;
using System.Data;

using Sqlzor.Drivers.Abstract;
using Sqlzor.Drivers.Models;

namespace Sqlzor.Drivers.SqlLite
{
    public class SQLiteSchemaMapper : AbstractSchemaMapper
    {
        public override SchemaModel MapSchema(Dictionary<string, DataTable> dataTables)
        {
            var schema = new SchemaModel();
            schema.ProviderName = ProviderNames.SQLite;
            schema.SourceDataTables = dataTables;

            schema.Columns = MapCollection(dataTables, "Columns", MapColumn);
            schema.Databases = MapCollection(dataTables, "Catalogs", MapDatabase);
            schema.DataSourceInformation = MapCollection(dataTables, "DataSourceInformation", MapDataSourceInformation);
            schema.DataTypes = MapCollection(dataTables, "DataTypes", MapDataType);
            schema.ForeignKeys = MapCollection(dataTables, "ForeignKeys", MapForeignKey);
            schema.Indexes = MapCollection(dataTables, "Indexes", MapIndex);
            schema.IndexColumns = MapCollection(dataTables, "IndexColumns", MapIndexColumn);
            schema.MetaDataCollections = MapCollection(dataTables, "MetaDataCollections", MapMetaDataCollection);
            schema.Procedures = new List<Procedure>();
            schema.ProcedureParameters = new List<ProcedureParameter>();
            schema.ReservedWords = MapCollection(dataTables, "ReservedWords", MapReservedWord);
            schema.Restrictions = new List<Restriction>();
            schema.Tables = MapCollection(dataTables, "Tables", MapTable);
            schema.Users = new List<User>();
            schema.Views = MapCollection(dataTables, "Views", MapView);
            schema.ViewColumns = MapCollection(dataTables, "ViewColumns", MapViewColumn);

            return schema;
        }

        protected override Column MapColumn(DataRow row)
        {
            var column = new Column();
            column.TableCatalog = row.GetString("TABLE_CATALOG");
            column.TableSchema = row.GetString("TABLE_SCHEMA");
            column.TableName = row.GetString("TABLE_NAME");
            column.ColumnName = row.GetString("COLUMN_NAME");
            column.OrdinalPosition = row.GetInt("ORDINAL_POSITION");
            column.ColumnDefault = row.GetString("COLUMN_DEFAULT");
            column.IsNullable = row.GetBool("IS_NULLABLE");
            column.DataType = row.GetString("DATA_TYPE");
            column.CharacterMaximumLength = row.GetNullableLong("CHARACTER_MAXIMUM_LENGTH");

            return column;
        }

        protected override Database MapDatabase(DataRow row)
        {
            var database = new Database();
            database.DatabaseName = row.GetString("CATALOG_NAME");

            return database;
        }

        protected override DataSourceInformation MapDataSourceInformation(DataRow row)
        {
            var dataSourceInformation = new DataSourceInformation();
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

        protected override DataType MapDataType(DataRow row)
        {
            var dataType = new DataType();
            dataType.TypeName = row.GetString("TypeName");
            dataType.ProviderDbType = row.GetInt("ProviderDbType");
            dataType.ColumnSize = row.GetLong("ColumnSize");
            dataType.CreateFormat = row.GetString("CreateFormat");
            dataType.CreateParameters = row.GetString("CreateParameters");
            dataType.DataTypeName = row.GetString("DataType");
            dataType.IsAutoincrementable = row.GetBool("IsAutoincrementable");
            dataType.IsBestMatch = row.GetBool("IsBestMatch");
            dataType.IsCaseSensitive = row.GetBool("IsCaseSensitive");
            dataType.IsFixedLength = row.GetNullableBool("IsFixedLength");
            dataType.IsFixedPrecisionScale = row.GetBool("IsFixedPrecisionScale");
            dataType.IsLong = row.GetBool("IsLong");
            dataType.IsNullable = row.GetNullableBool("IsNullable");
            dataType.IsSearchable = row.GetBool("IsSearchable");
            dataType.IsSearchableWithLike = row.GetBool("IsSearchableWithLike");
            dataType.IsUnsigned = row.GetNullableBool("IsUnsigned");
            dataType.MaximumScale = row.GetNullableShort("MaximumScale");
            dataType.MinimumScale = row.GetNullableShort("MinimumScale");
            dataType.IsConcurrencyType = row.GetNullableBool("IsConcurrencyType");
            dataType.IsLiteralSupported = row.GetNullableBool("IsLiteralSupported");
            dataType.LiteralPrefix = row.GetString("LiteralPrefix");
            dataType.LiteralSuffix = row.GetString("LiteralSuffix");

            return dataType;
        }

        protected override ForeignKey MapForeignKey(DataRow row)
        {
            var foreignKey = new ForeignKey();
            foreignKey.ConstraintCatalog = row.GetString("CONSTRAINT_CATALOG");
            foreignKey.ConstraintSchema = row.GetString("CONSTRAINT_SCHEMA");
            foreignKey.ConstraintName = row.GetString("CONSTRAINT_NAME");
            foreignKey.TableCatalog = row.GetString("TABLE_CATALOG");
            foreignKey.TableSchema = row.GetString("TABLE_SCHEMA");
            foreignKey.TableName = row.GetString("TABLE_NAME");

            return foreignKey;
        }

        protected override Models.Index MapIndex(DataRow row)
        {
            var index = new Models.Index();
            index.ConstraintCatalog = row.GetString("INDEX_CATALOG");
            index.ConstraintSchema = row.GetString("INDEX_SCHEMA");
            index.ConstraintName = row.GetString("INDEX_NAME");
            index.TableCatalog = row.GetString("TABLE_CATALOG");
            index.TableSchema = row.GetString("TABLE_SCHEMA");
            index.TableName = row.GetString("TABLE_NAME");
            index.IndexName = row.GetString("INDEX_NAME");
            index.IsPrimary = row.GetBool("PRIMARY_KEY");
            index.IsUnique = row.GetBool("UNIQUE");
            index.IsClustered = row.GetNullableBool("CLUSTERED");

            return index;
        }

        protected override IndexColumn MapIndexColumn(DataRow row)
        {
            var indexColumn = new IndexColumn();
            indexColumn.ConstraintCatalog = row.GetString("CONSTRAINT_CATALOG");
            indexColumn.ConstraintSchema = row.GetString("CONSTRAINT_SCHEMA");
            indexColumn.ConstraintName = row.GetString("CONSTRAINT_NAME");
            indexColumn.TableCatalog = row.GetString("TABLE_CATALOG");
            indexColumn.TableSchema = row.GetString("TABLE_SCHEMA");
            indexColumn.TableName = row.GetString("TABLE_NAME");
            indexColumn.ColumnName = row.GetString("COLUMN_NAME");
            indexColumn.OrdinalPostion = row.GetInt("ORDINAL_POSITION");
            indexColumn.IndexName = row.GetString("INDEX_NAME");

            return indexColumn;
        }

        protected override MetaDataCollection MapMetaDataCollection(DataRow row)
        {
            var collection = new MetaDataCollection();
            collection.CollectionName = row.GetString("CollectionName");
            collection.NumberOfRestrictions = row.GetInt("NumberOfRestrictions");
            collection.NumberOfIdentifierParts = row.GetNullableInt("NumberOfIdentifierParts");

            return collection;
        }

        protected override Procedure MapProcedure(DataRow row)
        {
            throw new NotSupportedException();
        }

        protected override ProcedureParameter MapProcedureParameter(DataRow row)
        {
            throw new NotSupportedException();
        }

        protected override ReservedWord MapReservedWord(DataRow row)
        {
            var reservedWord = new ReservedWord();
            reservedWord.Word = row.GetString("ReservedWord");

            return reservedWord;
        }

        protected override Restriction MapRestriction(DataRow row)
        {
            var restriction = new Restriction();
            restriction.CollectionName = row.GetString("CollectionName");
            restriction.RestrictionName = row.GetString("RestrictionName");
            restriction.RestrictionNumber = row.GetInt("RestrictionNumber");

            return restriction;
        }

        protected override Table MapTable(DataRow row)
        {
            var table = new Table();
            table.TableCatalog = row.GetString("TABLE_CATALOG");
            table.TableSchema = row.GetString("TABLE_SCHEMA");
            table.TableName = row.GetString("TABLE_NAME");
            table.TableType = row.GetString("TABLE_TYPE");

            return table;
        }

        protected override User MapUser(DataRow row)
        {
            throw new NotSupportedException();
        }

        protected override View MapView(DataRow row)
        {
            var view = new View();
            view.TableCatalog = row.GetString("TABLE_CATALOG");
            view.TableSchema = row.GetString("TABLE_SCHEMA");
            view.TableName = row.GetString("TABLE_NAME");

            return view;
        }

        protected override ViewColumn MapViewColumn(DataRow row)
        {
            var viewColumn = new ViewColumn();
            viewColumn.ViewCatalog = row.GetString("VIEW_CATALOG");
            viewColumn.ViewSchema = row.GetString("VIEW_SCHEMA");
            viewColumn.ViewName = row.GetString("VIEW_NAME");
            viewColumn.TableCatalog = row.GetString("TABLE_CATALOG");
            viewColumn.TableSchema = row.GetString("TABLE_SCHEMA");
            viewColumn.TableName = row.GetString("TABLE_NAME");
            viewColumn.ColumnName = row.GetString("COLUMN_NAME");

            return viewColumn;
        }
    }
}
