using Microsoft.Extensions.Configuration;

namespace MujeebOnline.Repositories
{
    public class DBConfigurationManager
    {
        private static IConfiguration _configuration;

        public DBConfigurationManager(IConfiguration configuration)
        {
             _configuration = configuration;
        }

        public static string GetDBConnection(string connectionName)
        {
            return _configuration.GetConnectionString(connectionName);
        }

    }
}
