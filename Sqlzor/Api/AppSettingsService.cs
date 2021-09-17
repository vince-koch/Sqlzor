using Microsoft.Extensions.Configuration;

using System;

namespace Sqlzor.Api
{
    public class AppSettingsService : IAppSettingsService
    {
        private IConfiguration _config;

        public string ConnectionStringsFile => Environment.ExpandEnvironmentVariables(
            GetValue<string>(nameof(ConnectionStringsFile)));

        public string InitialQueryText => GetValue<string>(nameof(InitialQueryText));

        public AppSettingsService(IConfiguration config)
        {
            _config = config;
        }

        protected T GetValue<T>(string key)
        {
            var value = _config.GetValue<T>("AppSettings:" + key);
            return value;
        }
    }
}
