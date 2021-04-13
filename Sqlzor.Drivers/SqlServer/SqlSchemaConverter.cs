using System;
using System.Data;

using Sqlzor.Data.Drivers.Abstract;
using Sqlzor.Data.Drivers.Models;

namespace Sqlzor.Data.Drivers.SqlServer
{
    public class SqlServerSchemaMapper : AbstractSchemaMapper
    {
        protected override Column MapColumn(DataRow row)
        {
            var column = new Column();
            column.TableCatalog = (string)row["TABLE_CATALOG"];
            column.TableSchema = (string)row["TABLE_SCHEMA"];
            column.TableName = (string)row["TABLE_NAME"];
            column.ColumnName = (string)row["COLUMN_NAME"];
            column.OrdinalPosition = (int)row["ORDINAL_POSITION"];
            column.ColumnDefault = (string)row["COLUMN_DEFAULT"];
            column.IsNullable = (bool)row["IS_NULLABLE"];
            column.DataType = (string)row["DATA_TYPE"];
            column.CharacterMaximumLength = (int)row["CHARACTER_MAXIMUM_LENGTH"];

            return column;
        }

        protected override Database MapDatabase(DataRow row)
        {
            var database = new Database();
            database.DatabaseName = (string)row["DATABASE_NAME"];

            return database;
        }

        protected override DataSourceInformation MapDataSourceInformation(DataRow row)
        {
            var dataSourceInformation = new DataSourceInformation();
            dataSourceInformation.CompositeIdentifierSeparatorPattern = (string)row["CompositeIdentifierSeparatorPattern"];
            dataSourceInformation.DataSourceProductName = (string)row["DataSourceProductName"];
            dataSourceInformation.DataSourceProductVersion = (string)row["DataSourceProductVersion"];
            dataSourceInformation.DataSourceProductVersionNormalized = (string)row["DataSourceProductVersionNormalized"];
            dataSourceInformation.GroupByBehavior = (int)row["GroupByBehavior"];
            dataSourceInformation.IdentifierPattern = (string)row["IdentifierPattern"];
            dataSourceInformation.IdentifierCase = (int)row["IdentifierCase"];
            dataSourceInformation.OrderByColumnsInSelect = (bool)row["OrderByColumnsInSelect"];
            dataSourceInformation.ParameterMarkerFormat = (string)row["ParameterMarkerFormat"];
            dataSourceInformation.ParameterNameMaxLength = (int)row["ParameterNameMaxLength"];
            dataSourceInformation.ParameterNamePattern = (string)row["ParameterNamePattern"];
            dataSourceInformation.QuotedIdentifierPattern = (string)row["QuotedIdentifierPattern"];
            dataSourceInformation.QuotedIdentifierCase = (int)row["QuotedIdentifierCase"];
            dataSourceInformation.StatementSeparatorPattern = (string)row["StatementSeparatorPattern"];
            dataSourceInformation.StringLiteralPattern = (string)row["StringLiteralPattern"];
            dataSourceInformation.SupportedJoinOperators = (int)row["SupportedJoinOperators"];

            return dataSourceInformation;
        }

        protected override DataType MapDataType(DataRow row)
        {
            var dataType = new DataType();
            dataType.TypeName = (string)row["TypeName"];
            dataType.ProviderDbType = (int)row["ProviderDbType"];
            dataType.ColumnSize = (long)row["ColumnSize"];
            dataType.CreateFormat = (string)row["CreateFormat"];
            dataType.CreateParameters = (string)row["CreateParameters"];
            dataType.DataTypeName = (string)row["DataType"];
            dataType.IsAutoincrementable = (bool)row["IsAutoincrementable"];
            dataType.IsBestMatch = (bool)row["IsBestMatch"];
            dataType.IsCaseSensitive = (bool)row["IsCaseSensitive"];
            dataType.IsFixedLength = (bool?)row["IsFixedLength"];
            dataType.IsFixedPrecisionScale = (bool)row["IsFixedPrecisionScale"];
            dataType.IsLong = (bool)row["IsLong"];
            dataType.IsNullable = (bool?)row["IsNullable"];
            dataType.IsSearchable = (bool)row["IsSearchable"];
            dataType.IsSearchableWithLike = (bool)row["IsSearchableWithLike"];
            dataType.IsUnsigned = (bool?)row["IsUnsigned"];
            dataType.MaximumScale = (short)row["MaximumScale"];
            dataType.MinimumScale = (short)row["MinimumScale"];
            dataType.IsConcurrencyType = (bool?)row["IsConcurrencyType"];
            dataType.IsLiteralSupported = (bool)row["IsLiteralSupported"];
            dataType.LiteralPrefix = (string)row["LiteralPrefix"];
            dataType.LiteralSuffix = (string)row["LiteralSuffix"];
            dataType.NativeDataType = (string)row["NativeDataType"];

            return dataType;
        }

        protected override ForeignKey MapForeignKey(DataRow row)
        {
            var foreignKey = new ForeignKey();
            foreignKey.ConstraintCatalog = (string)row["CONSTRAINT_CATALOG"];
            foreignKey.ConstraintSchema = (string)row["CONSTRAINT_SCHEMA"];
            foreignKey.ConstraintName = (string)row["CONSTRAINT_NAME"];
            foreignKey.TableCatalog = (string)row["TABLE_CATALOG"];
            foreignKey.TableSchema = (string)row["TABLE_SCHEMA"];
            foreignKey.TableName = (string)row["TABLE_NAME"];

            return foreignKey;
        }

        protected override Models.Index MapIndex(DataRow row)
        {
            var index = new Models.Index();
            index.ConstraintCatalog = (string)row["CONSTRAINT_CATALOG"];
            index.ConstraintSchema = (string)row["CONSTRAINT_SCHEMA"];
            index.ConstraintName = (string)row["CONSTRAINT_NAME"];
            index.TableCatalog = (string)row["TABLE_CATALOG"];
            index.TableSchema = (string)row["TABLE_SCHEMA"];
            index.TableName = (string)row["TABLE_NAME"];
            index.IndexName = (string)row["INDEX_NAME"];

            return index;
        }

        protected override IndexColumn MapIndexColumn(DataRow row)
        {
            var indexColumn = new IndexColumn();
            indexColumn.ConstraintCatalog = (string)row["CONSTRAINT_CATALOG"];
            indexColumn.ConstraintSchema = (string)row["CONSTRAINT_SCHEMA"];
            indexColumn.ConstraintName = (string)row["CONSTRAINT_NAME"];
            indexColumn.TableCatalog = (string)row["TABLE_CATALOG"];
            indexColumn.TableSchema = (string)row["TABLE_SCHEMA"];
            indexColumn.TableName = (string)row["TABLE_NAME"];
            indexColumn.ColumnName = (string)row["COLUMN_NAME"];
            indexColumn.OrdinalPostion = (int)row["ORDINAL_POSITION"];
            indexColumn.IndexName = (string)row["INDEX_NAME"];
        
            return indexColumn;
        }

        protected override MetaDataCollection MapMetaDataCollection(DataRow row)
        {
            var collection = new MetaDataCollection();
            collection.CollectionName = (string)row["CollectionName"];
            collection.NumberOfRestrictions = (int)row["NumberOfRestrictions"];
            collection.NumberOfIdentifierParts = (int)row["NumberOfIdentifierParts"];

            return collection;
        }

        protected override Procedure MapProcedure(DataRow row)
        {
            var procedure = new Procedure();
            procedure.SpecificCatalog = (string)row["SPECIFIC_CATALOG"];
            procedure.SpecificSchema = (string)row["SPECIFIC_SCHEMA"];
            procedure.SpecificName = (string)row["SPECIFIC_NAME"];
            procedure.RoutineCatalog = (string)row["ROUTINE_CATALOG"];
            procedure.RoutineSchema = (string)row["ROUTINE_SCHEMA"];
            procedure.RoutineName = (string)row["ROUTINE_NAME"];
            procedure.RoutineType = (string)row["ROUTINE_TYPE"];
            procedure.Created = (DateTime)row["CREATED"];
            procedure.LastAltered = (DateTime)row["LAST_ALTERED"];

            return procedure;
        }

        protected override ProcedureParameter MapProcedureParameter(DataRow row)
        {
            var parameter = new ProcedureParameter();
            parameter.SpecificCatalog = (string)row["SPECIFIC_CATALOG"];
            parameter.SpecificSchema = (string)row["SPECIFIC_SCHEMA"];
            parameter.SpecificName = (string)row["SPECIFIC_NAME"];
            parameter.OrdinalPosition = (int)row["ORDINAL_POSITION"];
            parameter.ParameterMode = (string)row["PARAMETER_MODE"];
            parameter.IsResult = (bool)row["IS_RESULT"];
            parameter.ParameterName = (string)row["PARAMETER_NAME"];
            parameter.DataType = (string)row["DATA_TYPE"];
            parameter.CharacterMaximumLength = (string)row["CHARACTER_MAXIMUM_LENGTH "];

            return parameter;
        }

        protected override ReservedWord MapReservedWord(DataRow row)
        {
            var reservedWord = new ReservedWord();
            reservedWord.Word = (string)row["ReservedWord"];

            return reservedWord;
        }

        protected override Restriction MapRestriction(DataRow row)
        {
            var restriction = new Restriction();
            restriction.CollectionName = (string)row["CollectionName"];    
            restriction.RestrictionName = (string)row["RestrictionName"];
            restriction.RestrictionNumber = (int)row["RestrictionNumber"];
    
            return restriction;
        }

        protected override Table MapTable(DataRow row)
        {
            var table = new Table();
            table.TableCatalog = (string)row["TABLE_CATALOG"];
            table.TableSchema = (string)row["TABLE_SCHEMA"];
            table.TableName = (string)row["TABLE_NAME"];
            table.TableType = (string)row["TABLE_TYPE"];

            return table;
        }

        protected override User MapUser(DataRow row)
        {
            var user = new User();
            user.Id = (string)row["UID"];
            user.UserName = (string)row["USER_NAME"];
            user.CreateDate = (DateTime)row["CREATEDATE"];
            user.UpdateDate = (DateTime)row["UPDATEDATE"];

            return user;
        }

        protected override View MapView(DataRow row)
        {
            var view = new View();           
            view.TableCatalog = (string)row["TABLE_CATALOG"];
            view.TableSchema = (string)row["TABLE_SCHEMA"];
            view.TableName = (string)row["TABLE_NAME"];

            return view;
        }

        protected override ViewColumn MapViewColumn(DataRow row)
        {
            var viewColumn = new ViewColumn();
            viewColumn.ViewCatalog = (string)row["VIEW_CATALOG"];
            viewColumn.ViewSchema = (string)row["VIEW_SCHEMA"];
            viewColumn.ViewName = (string)row["VIEW_NAME"];
            viewColumn.TableCatalog = (string)row["TABLE_CATALOG"];
            viewColumn.TableSchema = (string)row["TABLE_SCHEMA"];
            viewColumn.TableName = (string)row["TABLE_NAME"];
            viewColumn.ColumnName = (string)row["COLUMN_NAME"];

            return viewColumn;
        }
    }
}
