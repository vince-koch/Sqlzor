using System;
using System.IO;

using Newtonsoft.Json;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Drivers.Services
{
    public class SchemaPersistanceService : ISchemaPersistanceService
    {
        public SchemaModel LoadSchema(string connectionString)
        {
            var path = GetSchemaPath(connectionString);

            if (!File.Exists(path))
            {
                return null;
            }

            var json = File.ReadAllText(path);
            var schema = JsonConvert.DeserializeObject<SchemaModel>(json);

            ////foreach (var pair in schema.SourceDataTables)
            ////{
            ////    if (pair.Value != null)
            ////    {
            ////        pair.Value.TableName = pair.Key;
            ////    }
            ////}
            ////
            ///return schema;
            throw new NotImplementedException("todo: come back and fix this");
        }

        public void SaveSchema(string connectionString, SchemaModel schema)
        {
            var path = GetSchemaPath(connectionString);
            var json = JsonConvert.SerializeObject(schema);
            File.WriteAllText(path, json);
        }

        private string GetSchemaPath(string connectionString)
        {
            var filename = MD5.Calculate(connectionString.ToLower()) + ".json";

            var path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "SchemaCache",
                filename);

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            return path;
        }
    }
}
