using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Sqlzor.Drivers.Services;

namespace Sqlzor.Drivers.Postgres
{
    public class NpgsqlSchemaFetchService : SchemaFetchService
    {
        protected override async Task<DataTable> GetCollection(
            IDatabaseDriver databaseDriver,
            string connectionString,
            string collectionName)
        {
            DataTable dataTable = null;

            switch (collectionName)
            {
                case "MetaDataCollections":
                    dataTable = await base.GetCollection(databaseDriver, connectionString, collectionName);
                    
                    var row = dataTable.NewRow();
                    row["CollectionName"] = "ForeignKeys";
                    row["NumberOfRestrictions"] = 0;
                    row["NumberOfIdentifierParts"] = 0;
                    dataTable.Rows.Add(row);

                    Debug.WriteLine(dataTable.AsString());
                    break;

                case "ForeignKeys":
                    dataTable = await ExecuteScriptFile(databaseDriver, connectionString, "/SelectForeignKeys.sql");
                    dataTable.TableName = "ForeignKeys";
                    break;

                default:
                    dataTable = await base.GetCollection(databaseDriver, connectionString, collectionName);
                    break;
            }

            return dataTable;
        }

        
        protected async Task<DataTable> ExecuteScriptFile(
            IDatabaseDriver databaseDriver,
            string connectionString,
            string scriptFile)
        {
            using (var connection = await databaseDriver.OpenConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = await GetResourceText(GetType().Assembly, scriptFile);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    return dataTable;
                }
            }
        }

        private async Task<string> GetResourceText(Assembly assembly, string resourceFile)
        {
            var resourceSuffix = resourceFile
                .Replace('/', '.')
                .Replace('\\', '.');

            var resourceName = GetType().Assembly
                .GetManifestResourceNames()
                .Where(item => item.EndsWith(resourceSuffix))
                .Single();

            using (var stream = GetType().Assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var text = await reader.ReadToEndAsync();
                return text;
            }
        }
    }
}
