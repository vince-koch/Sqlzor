using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Services;

namespace Sqlzor.DbSchema.Postgres
{
    public class NpgsqlSchemaFetchService : SchemaFetchService
    {
        public NpgsqlSchemaFetchService(IDatabaseDriver databaseDriver)
            : base(databaseDriver)
        {
        }

        public override async Task<DataTable> GetSchemaCollection(
            string connectionString,
            string collectionName,
            string[] restrictions = null)
        {
            DataTable dataTable = null;

            switch (collectionName)
            {
                case "MetaDataCollections":
                    dataTable = await base.GetSchemaCollection(connectionString, collectionName, restrictions);
                    
                    var row = dataTable.NewRow();
                    row["CollectionName"] = "ForeignKeys";
                    row["NumberOfRestrictions"] = 0;
                    row["NumberOfIdentifierParts"] = 0;
                    dataTable.Rows.Add(row);

                    Debug.WriteLine(dataTable.AsString());
                    break;

                case "ForeignKeys":
                    dataTable = await ExecuteScriptFile(connectionString, "/SelectForeignKeys.sql");
                    dataTable.TableName = "ForeignKeys";
                    break;

                default:
                    dataTable = await base.GetSchemaCollection(connectionString, collectionName, restrictions);
                    break;
            }

            return dataTable;
        }

        
        protected async Task<DataTable> ExecuteScriptFile(
            string connectionString,
            string scriptFile)
        {
            using (var connection = await DatabaseDriver.OpenConnection(connectionString))
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
