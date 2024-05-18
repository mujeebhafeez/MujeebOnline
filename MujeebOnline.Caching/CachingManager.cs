using Microsoft.Extensions.Caching.Memory;

namespace MujeebOnline.Caching
{
    public class CachingManager 
    {
        private static readonly IMemoryCache _cache  = new MemoryCache(new MemoryCacheOptions());
        private static readonly object PadLock = new();
        private static CachingManager _instance;

        private CachingManager()
        {
          
        }
        public static CachingManager Instance
        {
            get
            {
                lock (PadLock) 
                {
                if (_instance != null) return _instance;
                    _instance = new CachingManager();
                }

                return _instance;
            }
        }
        public void Add(object value, string key, TimeSpan expiryTime)
        {
            if (_cache.TryGetValue(key, out _)) return;

            var cacheEntryOptions = new MemoryCacheEntryOptions() { AbsoluteExpiration = DateTime.Now.AddMinutes(expiryTime.TotalMinutes) };
            _cache.Set(key, value, cacheEntryOptions);
        }
        public T Get<T>(string key)
        {
            bool muj = _cache.TryGetValue(key, out var mujeeb);
            return _cache.Get<T>(key);
        }
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
