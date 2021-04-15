using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sqlzor.Data
{
    public class ConnectionStringService
    {
        private readonly AppSettingsService _appSettings;

        public ConnectionStringService(AppSettingsService appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<ConnectionStringEntry> GetConnectionStringEntry(string connectionName)
        {
            var entries = await GetConnectionStringEntries();
            var entry = entries.Single(item => item.Name == connectionName);
            return entry;
        }

        public async Task<ConnectionStringEntry[]> GetConnectionStringEntries()
        {
            using (var stream = File.OpenRead(_appSettings.ConnectionStringsFile))
            {
                var document = await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);

                var connectionStringEntries = document.Descendants()
                    .Where(item => item.Name.LocalName == "add")
                    .Select(item => new ConnectionStringEntry
                    {
                        Name = item.Attribute("name").Value,
                        ProviderName = item.Attribute("providerName")?.Value,
                        ConnectionString = item.Attribute("connectionString").Value
                    })
                    .ToArray();

                return connectionStringEntries;
            }
        }
    }
}
