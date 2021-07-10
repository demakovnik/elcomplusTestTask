namespace XMLJSON
{
    namespace Deserializers
    {
        interface Deserializer
        {
            Root getDeserializedObject(string response);
        }
    }
}
