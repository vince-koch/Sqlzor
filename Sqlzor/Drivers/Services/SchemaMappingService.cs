/*
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Sqlzor.Data.Drivers.Models;

namespace Sqlzor.Data.Drivers.Services
{
    public class SchemaMappingService
    {
        public SchemaModel MapSchema(string providerName, Dictionary<string, DataTable> dataTables)
        {
            var schema = new SchemaModel();
            schema.ProviderName = providerName;
            schema.SourceDataTables = dataTables;

            schema.Columns = MapSchemaTable<Column>(providerName, dataTables);
            schema.Databases = MapSchemaTable<Database>(providerName, dataTables);
            schema.DataSourceInformation = MapSchemaTable<DataSourceInformation>(providerName, dataTables);
            schema.DataTypes = MapSchemaTable<DataType>(providerName, dataTables);
            schema.ForeignKeys = MapSchemaTable<ForeignKey>(providerName, dataTables);
            schema.Indexes = MapSchemaTable<Models.Index>(providerName, dataTables);
            schema.IndexColumns = MapSchemaTable<IndexColumn>(providerName, dataTables);
            schema.MetaDataCollections = MapSchemaTable<MetaDataCollection>(providerName, dataTables);
            schema.Procedures = MapSchemaTable<Procedure>(providerName, dataTables);
            schema.ProcedureParameters = MapSchemaTable<ProcedureParameter>(providerName, dataTables);
            schema.ReservedWords = MapSchemaTable<ReservedWord>(providerName, dataTables);
            schema.Tables = MapSchemaTable<Table>(providerName, dataTables);
            schema.Users = MapSchemaTable<User>(providerName, dataTables);
            schema.Views = MapSchemaTable<View>(providerName, dataTables);
            schema.ViewColumns = MapSchemaTable<ViewColumn>(providerName, dataTables);

            return schema;
        }

        private List<TRow> MapSchemaTable<TRow>(string providerName, Dictionary<string, DataTable> dataTables)
            where TRow : new()
        {
            var rowType = typeof(TRow);

            // find the appropriate class attribute for the driver
            SchemaTableAttribute tableAttribute = null;
            try
            {
                var tableAttributeType = typeof(SchemaTableAttribute);
                var tableAttributes = rowType.GetCustomAttributes(tableAttributeType, false) as SchemaTableAttribute[];
                tableAttribute = tableAttributes.SingleOrDefault(item => item.ProviderName == providerName);
                if (tableAttribute == null)
                {
                    tableAttribute = tableAttributes.Single(item => item.ProviderName == null);
                }
            }
            catch (Exception thrown)
            {
                throw new Exception($"Unable to find an appropriate table attribute for ${rowType.Name}", thrown);
            }

            // build an attribute mapping for each property for the driver
            var columnAttributeType = typeof(SchemaColumnAttribute);
            var columnAttributeMap = rowType.GetProperties()
                .ToDictionary(
                property => property,
                property =>
                {
                    try
                    {
                        var columnAttributes = property.GetCustomAttributes(columnAttributeType, false) as SchemaColumnAttribute[];
                        var columnAttribute = columnAttributes.SingleOrDefault(item => item.ProviderName == providerName);
                        if (columnAttribute == null)
                        {
                            columnAttribute = columnAttributes.Single(item => item.ProviderName == null);
                        }

                        return columnAttribute;
                    }
                    catch (Exception thrown)
                    {
                        throw new Exception($"Unable to find an appropriate column attribute for {rowType.Name}.{property.Name}", thrown);
                    }
                })
                .ToArray();

            // map the rows property by property
            var mapped = dataTables.Values
                .Where(item => item != null)
                .Where(item => item.TableName == tableAttribute.TableName)
                .SelectMany(table => table.Rows.Cast<DataRow>())
                .Select((row, rowIndex) =>
                {
                    var item = new TRow();

                    foreach (var pair in columnAttributeMap)
                    {
                        try
                        {
                            if (pair.Value.IsIgnored)
                            {
                                continue;
                            }

                            var value = row[pair.Value.ColumnName];
                            if (value == DBNull.Value)
                            {
                                value = null;
                            }

                            value = pair.Value.Convert(value);

                            if (value != null && value.GetType() != pair.Key.PropertyType)
                            {
                                value = Convert.ChangeType(value, pair.Key.PropertyType);
                            }

                            pair.Key.SetValue(item, value);
                        }
                        catch (Exception thrown)
                        {                           
                            throw new Exception($"Error converting row #{rowIndex} of {tableAttribute.TableName}.{pair.Value.ColumnName} into property {rowType.Name}.{pair.Key.Name} ({pair.Key.PropertyType.Name})", thrown);
                        }
                    }

                    return item;
                })
                .ToList();

            return mapped;
        }
    }
}
*/