﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using Sqlzor.Data.Drivers.Models;

namespace Sqlzor.Data.Drivers.Services
{
    public class SchemaPersistanceService
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

            foreach (var pair in schema.SourceDataTables)
            {
                pair.Value.TableName = pair.Key;
            }

            return schema;
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
