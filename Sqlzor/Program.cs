using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Sqlzor.Data;
using Sqlzor.Data.Drivers;
using Sqlzor.Data.Drivers.Services;

namespace Sqlzor
{
    public class Program
    {
        //public static readonly IDatabaseDriver DatabaseDriver = new SQLiteDatabaseDriver();
        //public static readonly string DatabaseConnectionString = @"URI=file:C:\source\_settings\test.db";
        public static readonly IDatabaseDriver DatabaseDriver = new MySqlDatabaseDriver();
        public static readonly string DatabaseConnectionString = "server=mysql-rfam-public.ebi.ac.uk; port=4497; userid=rfamro; database=Rfam";

        public static void Main(string[] args)
        {
            var persistanceService = new SchemaPersistanceService();
            var schema = persistanceService.LoadSchema(DatabaseConnectionString);
            if (schema == null)
            {
                var fetchService = new SchemaFetchService();
                var dataTables = fetchService.FetchSchemaTables(DatabaseDriver, DatabaseConnectionString, 5)
                    .GetAwaiter()
                    .GetResult();

                Debug.WriteLine(dataTables["Restrictions"].AsString());

                var mappingService = new SchemaMappingService();
                schema = mappingService.MapSchema(DatabaseDriver.ProviderName, dataTables);

                persistanceService.SaveSchema(DatabaseConnectionString, schema);
            }

            //var builder = new SchemaTreeBuilder();
            //var tree = builder.BuildSchemaTree(schema);
            //var i = 0;

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
