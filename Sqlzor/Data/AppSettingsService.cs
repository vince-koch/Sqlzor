using Microsoft.Extensions.Configuration;

namespace Sqlzor.Data
{
    public class AppSettingsService
    {
        private IConfiguration _config;

        public string ConnectionStringsFile => GetValue<string>(nameof(ConnectionStringsFile));

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
