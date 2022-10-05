using Newtonsoft.Json;

namespace ApiTests.Deserializers
{
    public static class JsonDeserializer<T>
    {
        public static List<T>? DeserializeList(string json) =>
            JsonConvert.DeserializeObject<List<T>>(json);

        public static T? DeserializeObject(string json) =>
            JsonConvert.DeserializeObject<T>(json);
    }
}
