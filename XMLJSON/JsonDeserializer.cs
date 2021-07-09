using Newtonsoft.Json;

namespace XMLJSON.Deserializers.Json
{
    class JsonDeserializer:Deserializer
    {

        public Root getDeserializedObject(string response)
        {
            return (JsonRoot)JsonConvert.DeserializeObject<JsonRoot>(response);
        }
    }
}
