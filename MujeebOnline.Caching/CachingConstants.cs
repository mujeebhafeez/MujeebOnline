
namespace MujeebOnline.Caching
{
    public static class CachingConstants
    {
        public static readonly TimeSpan ExpireInSeconds = new(0,0,30);
        public static readonly TimeSpan ExpireInAMinute = new(0,0,60);
        public const string ConfigSettings = "ConfigSettings";
        public const string MujeebKey = "MujeebKey";
    }
}
