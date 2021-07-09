using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XMLJSON.Deserializers.Xml
{
    class XMLDeserializer : Deserializer
    {
        // using System.Xml.Serialization;
        // XmlSerializer serializer = new XmlSerializer(typeof(Root));
        // using (StringReader reader = new StringReader(xml))
        // {
        //    var test = (Root)serializer.Deserialize(reader);
        // }
        public Root getDeserializedObject(string response)
        {
            XmlRoot result = null; 
            XmlSerializer serializer = new XmlSerializer(typeof(XmlRoot));
             using (StringReader reader = new StringReader(response))
             {
                result = (XmlRoot)serializer.Deserialize(reader);
             }
            return (XmlRoot)result;

        }
    }
}
