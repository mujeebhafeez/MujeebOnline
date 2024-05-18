using Newtonsoft.Json;

namespace MujeebOnline.Utility
{
    public static class SerializationExtensions
    {
        public static string GetJsonSerializedSerialize<T>(this T entity)
        {
            return JsonConvert.SerializeObject(entity);
        }

        public static T GetJsonDeserialized<T>(this string stringValue) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(stringValue);
                    
        }
    }
}