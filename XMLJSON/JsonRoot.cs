using System.Collections.Generic;

namespace XMLJSON.Deserializers
{
    class JsonRoot:Root
    {
        public List<string> Values { get; set; }

        public List<string> getValues()
        {
            return this.Values;
        }
    }         
}
