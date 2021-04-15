using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sqlzor.Data;
using Sqlzor.Drivers;

namespace Sqlzor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartupWeb(args);
            //StartupExe(args).GetAwaiter().GetResult();
        }

        #region Web

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

        #endregion

        #region Exe

        private static async Task StartupExe(string[] args)
        {
            var services = BuildServiceProvider();

            var connectionStringService = services.GetService<ConnectionStringService>();
            var connectionStringEntry = await connectionStringService.GetConnectionStringEntry("Postgres LOCAL Admin");

            var databaseDriverManager = services.GetService<IDatabaseDriverManagerService>();
            var schema = await databaseDriverManager.GetSchema(connectionStringEntry.ProviderName, connectionStringEntry.ConnectionString);
        }

        private static ServiceProvider BuildServiceProvider()
        {
            var serviceBuilder = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appSettings.json")
                .Build();

            var startup = new Startup(configuration);
            startup.ConfigureServices(serviceBuilder);

            var services = serviceBuilder.BuildServiceProvider();
            return services;
        }

        #endregion
    }
}
