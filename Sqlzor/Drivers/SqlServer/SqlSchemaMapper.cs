using System;
using System.Collections.Generic;
using System.Data;

using Sqlzor.Drivers.Abstract;
using Sqlzor.Drivers.Models;

namespace Sqlzor.Drivers.SqlServer
{
    public class SqlSchemaMapper : AbstractSchemaMapper
    {
        public override SchemaModel MapSchema(DataTable[] dataTables)
        {
            var schema = new SchemaModel();
            schema.ProviderName = ProviderNames.SqlServer;
            schema.SourceDataTables = dataTables;

            schema.Columns = MapCollection(dataTables, "Columns", MapColumn);
            schema.Databases = MapCollection(dataTables, "Databases", MapDatabase);
            schema.DataSourceInformation = MapCollection(dataTables, "DataSourceInformation", MapDataSourceInformation);
            schema.DataTypes = MapCollection(dataTables, "DataTypes", MapDataType);
            schema.ForeignKeys = MapCollection(dataTables, "Foreign Keys", MapForeignKey);
            schema.Indexes = MapCollection(dataTables, "Indexes", MapIndex);
            schema.IndexColumns = MapCollection(dataTables, "IndexColumns", MapIndexColumn);
            schema.MetaDataCollections = MapCollection(dataTables, "MetaDataCollections", MapMetaDataCollection);
            schema.Procedures = MapCollection(dataTables, "Procedures", MapProcedure);
            schema.ProcedureParameters = MapCollection(dataTables, "Procedure Parameters", MapProcedureParameter);
            schema.ReservedWords = MapCollection(dataTables, "ReservedWords", MapReservedWord);
            schema.Restrictions = MapCollection(dataTables, "Restrictions", MapRestriction);
            schema.Tables = MapCollection(dataTables, "Tables", MapTable);
            schema.Users = MapCollection(dataTables, "Users", MapUser);
            schema.Views = MapCollection(dataTables, "Views", MapView);
            schema.ViewColumns = MapCollection(dataTables, "ViewColumns", MapViewColumn);

            return schema;
        }

        protected override ColumnModel MapColumn(DataRow row)
        {
            var column = new ColumnModel();
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

        protected override DatabaseModel MapDatabase(DataRow row)
        {
            var database = new DatabaseModel();
            database.DatabaseName = row.GetString("DATABASE_NAME");

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
            dataType.IsLiteralSupported = row.GetBool("IsLiteralSupported");
            dataType.LiteralPrefix = row.GetString("LiteralPrefix");
            dataType.LiteralSuffix = row.GetString("LiteralSuffix");
            dataType.NativeDataType = row.GetString("NativeDataType");

            return dataType;
        }

        protected override ForeignKeyModel MapForeignKey(DataRow row)
        {
            var foreignKey = new ForeignKeyModel();
            foreignKey.ConstraintCatalog = row.GetString("CONSTRAINT_CATALOG");
            foreignKey.ConstraintSchema = row.GetString("CONSTRAINT_SCHEMA");
            foreignKey.ConstraintName = row.GetString("CONSTRAINT_NAME");
            foreignKey.TableCatalog = row.GetString("TABLE_CATALOG");
            foreignKey.TableSchema = row.GetString("TABLE_SCHEMA");
            foreignKey.TableName = row.GetString("TABLE_NAME");

            return foreignKey;
        }

        protected override Models.IndexModel MapIndex(DataRow row)
        {
            var index = new Models.IndexModel();
            index.ConstraintCatalog = row.GetString("CONSTRAINT_CATALOG");
            index.ConstraintSchema = row.GetString("CONSTRAINT_SCHEMA");
            index.ConstraintName = row.GetString("CONSTRAINT_NAME");
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

        protected override MetaDataCollectionModel MapMetaDataCollection(DataRow row)
        {
            var collection = new MetaDataCollectionModel();
            collection.CollectionName = row.GetString("CollectionName");
            collection.NumberOfRestrictions = row.GetInt("NumberOfRestrictions");
            collection.NumberOfIdentifierParts = row.GetInt("NumberOfIdentifierParts");

            return collection;
        }

        protected override ProcedureModel MapProcedure(DataRow row)
        {
            var procedure = new ProcedureModel();
            procedure.SpecificCatalog = row.GetString("SPECIFIC_CATALOG");
            procedure.SpecificSchema = row.GetString("SPECIFIC_SCHEMA");
            procedure.SpecificName = row.GetString("SPECIFIC_NAME");
            procedure.RoutineCatalog = row.GetString("ROUTINE_CATALOG");
            procedure.RoutineSchema = row.GetString("ROUTINE_SCHEMA");
            procedure.RoutineName = row.GetString("ROUTINE_NAME");
            procedure.RoutineType = row.GetString("ROUTINE_TYPE");
            procedure.Created = row.GetDateTime("CREATED");
            procedure.LastAltered = row.GetDateTime("LAST_ALTERED");

            return procedure;
        }

        protected override ProcedureParameterModel MapProcedureParameter(DataRow row)
        {
            var parameter = new ProcedureParameterModel();
            parameter.SpecificCatalog = row.GetString("SPECIFIC_CATALOG");
            parameter.SpecificSchema = row.GetString("SPECIFIC_SCHEMA");
            parameter.SpecificName = row.GetString("SPECIFIC_NAME");
            parameter.OrdinalPosition = row.GetInt("ORDINAL_POSITION");
            parameter.ParameterMode = row.GetString("PARAMETER_MODE");
            parameter.IsResult = row.GetBool("IS_RESULT");
            parameter.ParameterName = row.GetString("PARAMETER_NAME");
            parameter.DataType = row.GetString("DATA_TYPE");
            parameter.CharacterMaximumLength = row.GetString("CHARACTER_MAXIMUM_LENGTH");

            return parameter;
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
            var user = new UserModel();
            user.Id = row.GetString("UID");
            user.UserName = row.GetString("USER_NAME");
            user.CreateDate = row.GetDateTime("CREATEDATE");
            user.UpdateDate = row.GetDateTime("UPDATEDATE");

            return user;
        }

        protected override ViewModel MapView(DataRow row)
        {
            var view = new ViewModel();
            view.TableCatalog = row.GetString("TABLE_CATALOG");
            view.TableSchema = row.GetString("TABLE_SCHEMA");
            view.TableName = row.GetString("TABLE_NAME");

            return view;
        }

        protected override ViewColumnModel MapViewColumn(DataRow row)
        {
            var viewColumn = new ViewColumnModel();
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
