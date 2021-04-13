using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sqlzor.Drivers;

namespace Sqlzor
{
    public class Program
    {
        //public static readonly string DatabaseProviderName = ProviderNames.MySql;
        //public static readonly string DatabaseConnectionString = "server=mysql-rfam-public.ebi.ac.uk; port=4497; userid=rfamro; database=Rfam";
        //public static readonly string DatabaseProviderName = ProviderNames.SQLite;
        //public static readonly string DatabaseConnectionString = @"URI=file:C:\source\_settings\test.db";
        public static readonly string DatabaseProviderName = ProviderNames.Postgres;
        public static readonly string DatabaseConnectionString = "Host=hh-pgsql-public.ebi.ac.uk; Port=5432; Database=pfmegrnargs; Username=reader; Password=NWDMCE5xdipIjRrp";       

        public static void Main(string[] args)
        {
            StartupExe(args);
            //StartupWeb(args);
        }

        private static void StartupExe(string[] args)
        {
            var serviceBuilder = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appSettings.json")
                .Build();

            var startup = new Startup(configuration);
            startup.ConfigureServices(serviceBuilder);

            var services = serviceBuilder.BuildServiceProvider();
            var databaseDriverManager = services.GetService<IDatabaseDriverManagerService>();
            var schema = databaseDriverManager.GetSchema(DatabaseProviderName, DatabaseConnectionString)
                .GetAwaiter()
                .GetResult();

            var i = 0;
            //var builder = new SchemaTreeBuilder();
            //var tree = builder.BuildSchemaTree(schema);
            //var i = 0;
        }

        private static void StartupWeb(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
