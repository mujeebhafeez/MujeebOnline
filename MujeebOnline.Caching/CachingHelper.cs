using MujeebOnline.ExceptionsAndLoggings;

namespace MujeebOnline.Caching
{
    public static class CachingHelper
    {
        public static async Task<string> GetMujeeb()
        {
            string mujeebvalue = CachingManager.Instance.Get<string>(CachingConstants.MujeebKey);
            if (mujeebvalue != null) return mujeebvalue;

            mujeebvalue = "abcd";
            CachingManager.Instance.Add(mujeebvalue, CachingConstants.MujeebKey, CachingConstants.ExpireInSeconds);
            return mujeebvalue;

        }


        public static async Task<List<ConfigSettings>> GetConfigList()
        {
            List<ConfigSettings> configs = CachingManager.Instance.Get<List<ConfigSettings>>(CachingConstants.ConfigSettings);
            if (configs != null) return configs;

            configs = new List<ConfigSettings>()
                     {
                new ConfigSettings { ConfigKey = "Conf1",ConfigValue = "Val1" },
                new ConfigSettings { ConfigKey = "Conf2",ConfigValue = "Val2" },
                new ConfigSettings { ConfigKey = "Conf3",ConfigValue = "Val3" },
                     };
            CachingManager.Instance.Add(configs, CachingConstants.ConfigSettings, CachingConstants.ExpireInSeconds);
            return configs;
        }


        public static async Task<ConfigSettings> GetConfigByKey(string configKey)
        {
            ConfigSettings configValue = (await GetConfigList()).Find(x => x.ConfigKey == configKey);
            return configValue;


        }
    }
}
