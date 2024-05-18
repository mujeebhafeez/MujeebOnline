using Microsoft.Extensions.Configuration;

namespace MujeebOnline.Utility
{
    public class ConfigurationManager
    {
        private static IConfiguration _configuration;
        public ConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static IConfiguration GetSection(string sectionName)
        {
            return _configuration.GetSection(sectionName);
        }
        public static string GetValue(string key)
        {
            return _configuration[key];
        }
        public static T GetArrayValue<T>(string key) => _configuration.GetSection(key).Get<T>();
    }
}
